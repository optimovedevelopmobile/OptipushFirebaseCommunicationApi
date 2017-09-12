using System;
using System.Collections.Generic;

namespace OptipushFirebaseCommunicationApi.Entities
{
    public class OptipushDynamicLink
    {
        public int ID { get; set; }
        public string publicName { get; set; }
        public Dictionary<String, Object> DynamicLinkData { get; set; }
        public Uri Url { get; set; }
        public DynamicLinkStatus Status { get; set; }
        public DynamicLinkType Type { get; set; }
    }

    public enum DynamicLinkStatus { Available, Deleted }
    public enum DynamicLinkType { Regular, Personalized }
}
