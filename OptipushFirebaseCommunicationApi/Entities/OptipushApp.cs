using System.Collections.Generic;

namespace OptipushFirebaseCommunicationApi.Entities
{
    public class OptipushApp
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string OS { get; set; }
        public string PackageName { get; set; }
        public List<OptipushDynamicLink> DynamicLinks { get; set; }
    }

    public enum OptipushAppStatus
    {
        Available, Deleted
    }
}
