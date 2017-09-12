using System.Collections.Generic;

namespace OptipushFirebaseCommunicationApi.Entities
{
    public class OptipushBrand
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ProjectID { get; set; }
        public string WebApiKey { get; set; }
        public string SenderID { get; set; }
        public string ServerKey { get; set; }
        public string DBUrl { get; set; }
        public string StorageBucket { get; set; }
        public string DynamicLinkDomain { get; set; }
        public List<OptipushApp> Apps { get; set; }
    }
}
