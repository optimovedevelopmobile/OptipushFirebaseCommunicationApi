using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptipushFirebaseCommunicationApi.Entities
{
    class PushMessageRequestData
    {
        string ServerKey { get; set; }
        string Title { get; set; }
        Uri DynamicLink { get; set; }
        string OS { get; set; }
        string PackageName { get; set; }
    }
}
