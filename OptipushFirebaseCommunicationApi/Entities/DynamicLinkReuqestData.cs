using System;

namespace OptipushFirebaseCommunicationApi.Entities
{
    class DynamicLinkReuqestData
    {
        string WebApiKey { get; set; }
        string DynamicLinkDomain { get; set; }
        Uri DynamicLink { get; set; }
        string OS { get; set; }
        string PackageName { get; set; }
    }
}
