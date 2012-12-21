using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EsriUK.AGOLWrapper.Json
{
    [DataContract(Namespace = "")]
    public class JsonFolder
    {
        [OnDeserializing]
        public void OnDeserializing(StreamingContext context)
        {
            username = String.Empty;
            id = String.Empty;
            title = String.Empty;
        }

        [DataMember(IsRequired = true)]
        public string username;
        [DataMember(IsRequired = true)]
        public string id;
        [DataMember(IsRequired = true)]
        public string title;
    }
}
