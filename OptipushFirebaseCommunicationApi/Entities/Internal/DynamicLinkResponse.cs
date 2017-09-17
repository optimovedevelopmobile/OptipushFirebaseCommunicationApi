using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptipushFirebaseCommunicationApi.Entities.Internal
{
    internal class DynamicLinkResponse
    {
        public string ShortLink { get; set; }
        public string PreviewLink { get; set; }
        public List<object> Warning { get; set; }
    }
}
