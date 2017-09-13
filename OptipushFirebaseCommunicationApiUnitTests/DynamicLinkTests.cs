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
        [TestMethod]
        public void WhenAllDataIsValid_DynamicLinkCreatedSuccessfully()
        {
            DynamicLinkReuqestData requestData = new DynamicLinkReuqestData.Factory("test.domain")
                .SetLinkData("test_screen", new Dictionary<string, object>
                {
                    { "test_param1", "Test Value 1" },
                    { "test_param2", 2 }
                })
                .SetPackageName(OptipushApp.SupportedOS.Andorid, "com.test.package")
                .Create();
            var expectedJson = "{\"dynamicLinkInfo\":{\"dynamicLinkDomain\":\"test.domain\",\"link\":\"http://optimove.com/test_screen?test_param1=Test Value 1&test_param2=2\",\"androidInfo\":{\"androidPackageName\":\"com.test.package\"}}}";
            Assert.AreEqual(expectedJson, requestData.ToJson());
        }
    }
}
