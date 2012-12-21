using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EsriUK.AGOLWrapper.Json
{
    // {"success" : true,"id" : "99aa3416340c4c91989b1af6c5453ce2","item" : "Test.zip","itemType" : "file","folder" : "01a1484edcb14e0d99cb5b1266e9657b"}
    [DataContract(Namespace = "")]
    public class JsonAddItemResponse
    {
        [OnDeserializing]
        public void OnDeserializing(StreamingContext context)
        {
            success = false;
            id = String.Empty;
            item = String.Empty;
            itemType = String.Empty;
            folder = String.Empty;
        }

        [DataMember(IsRequired = true)]
        public bool success;
        [DataMember(IsRequired = true)]
        public string id;
        [DataMember(IsRequired = true)]
        public string item;
        [DataMember(IsRequired = true)]
        public string itemType;
        [DataMember(IsRequired = true)]
        public string folder;
    }
}
