using System.Collections.Generic;

namespace OptipushFirebaseCommunicationApi.Entities
{
    public class OptipushApp
    {
        public int ID { get; set; }
        public string FirebaseAppId { get; set; }
        public string Name { get; set; }
        public SupportedOS OS { get; set; }
        public string PackageName { get; set; }
        public List<OptipushDynamicLink> DynamicLinks { get; set; }

        public enum Status
        {
            Available, Deleted
        }

        public enum SupportedOS
        {
            Andorid, iOS
        }
    }
}
