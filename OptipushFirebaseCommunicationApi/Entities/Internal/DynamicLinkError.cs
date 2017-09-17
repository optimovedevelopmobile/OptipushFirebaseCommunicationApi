using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptipushFirebaseCommunicationApi.Entities.Internal
{
    public class DynamicLinkError
    {
        public string Message { get; }

        public DynamicLinkError(string message)
        {
            this.Message = message;
        }
    }
}
