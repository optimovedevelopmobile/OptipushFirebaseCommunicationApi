using OptipushFirebaseCommunicationApi.Entities;
using System;
using System.Collections.Generic;

namespace OptipushFirebaseCommunicationApi
{
    public class FirebaseInteractor
    {
        public delegate void DynamicLinkCallback(OptipushDynamicLink dynamicLink, DynamicLinkError error);
        public delegate void TestCampaignCallback(TestCampaignError error);

        private OptipushBrand brand;
        private OptipushApp app;

        public FirebaseInteractor(OptipushBrand brand, OptipushApp app)
        {
            this.brand = brand;
            this.app = app;
        }

        public void CreateDynamicLink(string screenName, Dictionary<string, object> d, DynamicLinkCallback callback)
        {

        }

        public void ExecuteTestCampaign(OptipushCampaignData data, TestCampaignCallback callback)
        {

        }
    }

    public class DynamicLinkError
    {
        public string Message { get; set; }
    }

    public class TestCampaignError
    {
        public string Message { get; set; }
    }
}
