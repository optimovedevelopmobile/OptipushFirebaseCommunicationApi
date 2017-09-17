using Newtonsoft.Json;
using OptipushFirebaseCommunicationApi.Entities;
using OptipushFirebaseCommunicationApi.Entities.Internal;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OptipushFirebaseCommunicationApi
{
    public class FirebaseInteractor
    {
        public delegate void DynamicLinkCallback(Uri dynamicLinkUri, DynamicLinkError error);
        public delegate void TestCampaignCallback(TestCampaignError error);

        private OptipushBrand brand;
        private OptipushApp app;

        public FirebaseInteractor(OptipushBrand brand, OptipushApp app)
        {
            this.brand = brand;
            this.app = app;
        }

        public async void CreateDynamicLink(string screenName, Dictionary<string, object> data, DynamicLinkCallback callback)
        {
            DynamicLinkReuqestData requestData = new DynamicLinkReuqestData.Factory(brand.DynamicLinkDomain)
                .SetLinkData(screenName, data)
                .SetPackageName(OptipushApp.SupportedOS.Andorid, app.PackageName)
                .Create();
            DynamicLinkResponse dynamicLinkResponse = await SendDynamicLinkRequest(requestData);
            if (dynamicLinkResponse == null)
                callback(null, new DynamicLinkError("Failed to create dynamic link due to Firebase request error"));
            else
                callback(new Uri(dynamicLinkResponse.ShortLink), null);
        }

        private async Task<DynamicLinkResponse> SendDynamicLinkRequest(DynamicLinkReuqestData requestData)
        {
            HttpClient client = new HttpClient();
            string dynamicLinkUri = $"https://firebasedynamiclinks.googleapis.com/v1/shortLinks?key={brand.WebApiKey}";
            HttpResponseMessage response = await client.PostAsync(dynamicLinkUri, new StringContent(requestData.ToJson()));
            if (!response.IsSuccessStatusCode)
                return null;
            string dynamicLinkJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DynamicLinkResponse>(dynamicLinkJson);
        }

        public void ExecuteTestCampaign(OptipushCampaignData data, TestCampaignCallback callback)
        {

        }
    }

    public class TestCampaignError
    {
        public string Message { get; set; }
    }
}
