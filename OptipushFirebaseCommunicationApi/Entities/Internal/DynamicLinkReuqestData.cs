using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OptipushFirebaseCommunicationApi.Entities
{
    class DynamicLinkReuqestData
    {
        private readonly Dictionary<string, object> data;

        private DynamicLinkReuqestData(Dictionary<string, object> data)
        {
            this.data = data;
        }

        internal string ToJson()
        {
            return JsonConvert.SerializeObject(data, Formatting.None);
        }

        internal class Factory
        {
            private string dynamicLinkDomain;
            private Dictionary<string, object> data;

            internal Factory(string dynamicLinkDomain)
            {
                this.dynamicLinkDomain = dynamicLinkDomain;
                this.data = new Dictionary<string, object>();
                data.Add(RequestKeys.DynamicLinkDomain, dynamicLinkDomain);
            }

            internal Factory SetLinkData(string screenName, IDictionary<string, object> data)
            {
                if (Regex.IsMatch(screenName, @"^[A-Z\s]+$"))
                {
                    throw new ArgumentException("Screen name contains illegal characters", "screenName");
                }
                StringBuilder builder = new StringBuilder("http://optimove.com/");
                builder.Append(screenName);
                builder.Append("?");
                foreach(KeyValuePair<string, object> entry in data)
                {
                    if (Regex.IsMatch(entry.Key, "^[A-Z\\s]+$"))
                    {
                        throw new ArgumentException($"DynamicLink data key {entry.Key} contains illegal characters");
                    }
                    builder.Append($"{entry.Key}={entry.Value}&");
                }
                builder.Remove(builder.Length - 1, 1);
                this.data.Add(RequestKeys.DynamicLinkLink, builder.ToString());
                return this;
            }

            internal Factory SetPackageName(OptipushApp.SupportedOS os, string packageName)
            {
                var infoKey = "";
                var packageKey = "";
                switch (os)
                {
                    case OptipushApp.SupportedOS.Andorid:
                        infoKey = RequestKeys.AndroidInfo;
                        packageKey = RequestKeys.AndroidPackageName;
                        break;
                    case OptipushApp.SupportedOS.iOS:
                        infoKey = RequestKeys.IosInfo;
                        packageKey = RequestKeys.IosBundleId;
                        break;
                }
                data.Add(infoKey, new Dictionary<string, object>
                {
                    { packageKey, packageName }
                });
                return this;
            }

            internal DynamicLinkReuqestData Create()
            {
                if (data.Keys.Count < 3)
                {
                    throw new InvalidOperationException("Illegal call to Create before calling all the setters, missing dynamic link request keys.");
                }
                return new DynamicLinkReuqestData(new Dictionary<string, object>
                {
                    { RequestKeys.DynamicLinkInfo, data}
                });
            }
        }

        private struct RequestKeys
        {
            internal const string DynamicLinkInfo = "dynamicLinkInfo";
            internal const string DynamicLinkDomain = "dynamicLinkDomain";
            internal const string DynamicLinkLink = "link";
            internal const string AndroidInfo = "androidInfo";
            internal const string AndroidPackageName = "androidPackageName";
            internal const string IosInfo = "iosInfo";
            internal const string IosBundleId = "iosBundleId";
        }
    }
}
