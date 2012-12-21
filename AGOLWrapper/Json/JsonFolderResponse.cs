using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EsriUK.AGOLWrapper.Json
{
    [DataContract(Namespace = "")]
    public class JsonFolderResponse
    {  
        [OnDeserializing]
        public void OnDeserializing(StreamingContext context)
        {
            success = false;
            folder = null;
        }

        [DataMember(IsRequired = true)]
        public bool success;
        [DataMember(IsRequired = true)]
        public JsonFolder folder;
    }
}
