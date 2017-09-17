using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptipushFirebaseCommunicationApi.Entities;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace OptipushFirebaseCommunicationApiUnitTests
{
    [TestClass]
    public class DynamicLinkTests
    {
        private string dynamicLinkDomain;
        private string appNamespace;
        private string screenName;
        private Dictionary<string, object> dynamicLinkData;

        [TestInitialize]
        public void initializeTest()
        {
            dynamicLinkDomain = "test.domain";
            appNamespace = "com.test.package";
            screenName = "test_screen";
            dynamicLinkData = new Dictionary<string, object>
                {
                    { "test_param1", "Test Value 1" },
                    { "test_param2", 2 }
                };
        }

        [TestMethod]
        public void WhenAllDataIsValid_DynamicLinkCreatedSuccessfully()
        {
            DynamicLinkReuqestData requestData = new DynamicLinkReuqestData.Factory(dynamicLinkDomain)
                .SetLinkData(screenName, dynamicLinkData)
                .SetPackageName(OptipushApp.SupportedOS.Andorid, appNamespace)
                .Create();
            var expectedJson = "{\"dynamicLinkInfo\":{\"dynamicLinkDomain\":\"test.domain\",\"link\":\"http://optimove.com/test_screen?test_param1=Test Value 1&test_param2=2\",\"androidInfo\":{\"androidPackageName\":\"com.test.package\"}}}";
            Assert.AreEqual(expectedJson, requestData.ToJson());
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void WhenScreenNameIsInvalid_InvalidErrorThrown()
        {
            DynamicLinkReuqestData requestData = new DynamicLinkReuqestData.Factory(dynamicLinkDomain)
                .SetLinkData("H", dynamicLinkData)
                .SetPackageName(OptipushApp.SupportedOS.Andorid, appNamespace)
                .Create();
        }
    }
}
