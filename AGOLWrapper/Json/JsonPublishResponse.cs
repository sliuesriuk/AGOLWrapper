using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EsriUK.AGOLWrapper.Json
{
    // {"services": [{"type":"Feature Service", "serviceurl":"http://www.arcgis.com/fa019fbbfbb845d08cc9f0acde6dd8af/arcgis/rest/services/Streets_Service/FeatureServer", "size":2656729, "jobId":"ff07c87a-dccd-46b4-9597-446dcda248ff", "serviceItemId":"2e39b0b9550a40709f02a697cd9fc4fb"}]}
    [DataContract(Namespace = "")]
    public class JsonPublishResponse
    {
        [OnDeserializing]
        public void OnDeserializing(StreamingContext context)
        {
            services = null;
        }

        [DataMember(IsRequired = true)]
        public JsonServiceResponse[] services;
    }

    public class JsonServiceResponse
    {
        [OnDeserializing]
        public void OnDeserializing(StreamingContext context)
        {
            type = String.Empty;
            serviceurl = String.Empty;
            size = String.Empty;
            jobId = String.Empty;
            serviceItemId = String.Empty;
        }

        [DataMember(IsRequired = true)]
        public string type;
        [DataMember(IsRequired = true)]
        public string serviceurl;
        [DataMember(IsRequired = true)]
        public string size;
        [DataMember(IsRequired = true)]
        public string jobId;
        [DataMember(IsRequired = true)]
        public string serviceItemId;
    }
}
