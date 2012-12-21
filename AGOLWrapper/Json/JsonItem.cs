using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EsriUK.AGOLWrapper.Json
{
    [DataContract(Namespace = "")]
    public class JsonItem
    {
        [OnDeserializing]
        public void OnDeserializing(StreamingContext context)
        {
            success = false;
            itemId = String.Empty;
        }

        [DataMember(IsRequired = true)]
        public bool success;
        [DataMember(IsRequired = true)]
        public string itemId;
    }
}
