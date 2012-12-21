using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EsriUK.AGOLWrapper.Parameters
{
    [DataContract(Namespace = "")]
    public class PublishParametersShapefile : PublishParameters
    {
        [DataMember(IsRequired = true)]
        public string name;
        [DataMember(IsRequired = false, EmitDefaultValue=false)]
        public string description;
        [DataMember(IsRequired = false, EmitDefaultValue=true)]
        public int maxRecordCount = -1;
        [DataMember(IsRequired = false, EmitDefaultValue=false)]
        public string copyrightText;
        
        //TODO: sort this out - these are really Json structures not strings.
        [DataMember(IsRequired = false, EmitDefaultValue=false)]
        public string layerInfo;
        [DataMember(IsRequired = false, EmitDefaultValue=true)]
        public string targetSR = "{wkid: 4326 }";
    }
}
