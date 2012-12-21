using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EsriUK.AGOLWrapper.Json
{
    // {"status" : "processing","statusMessage" : "processing","itemId" : "99aa3416340c4c91989b1af6c5453ce2"}
    [DataContract(Namespace="")]
    public class JsonStatusResponse
    {
        [OnDeserializing]
        public void OnDeserializing(StreamingContext context)
        {
            status = String.Empty;
            statusMessage = String.Empty;
            itemId = String.Empty;
        }

        [DataMember(IsRequired = true)]
        public string status;
        [DataMember(IsRequired = true)]
        public string statusMessage;
        [DataMember(IsRequired = true)]
        public string itemId;
    }
}
