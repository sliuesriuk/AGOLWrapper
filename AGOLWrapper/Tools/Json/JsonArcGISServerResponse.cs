using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EsriUK.AGOLWrapper.Tools.Json
{
    [DataContract(Namespace = "")]
    public class JsonArcGISServerResponse
    {
        [OnDeserializing]
        public void OnDeserializing(StreamingContext context)
        {
            currentVersion = String.Empty;
            folders = null;
            services = null;
        }

        [DataMember(IsRequired = true)]
        public string currentVersion;
        [DataMember(IsRequired = true)]
        public string[] folders;
        [DataMember(IsRequired = true)]
        public JsonArcGISServerService[] services;
    }

    [DataContract(Namespace = "")]
    public class JsonArcGISServerService
    {
        [OnDeserializing]
        public void OnDeserializing(StreamingContext context)
        {
            name = String.Empty;
            type = String.Empty;
        }

        [DataMember(IsRequired = true)]
        public string name;
        [DataMember(IsRequired = true)]
        public string type;
    }
}
