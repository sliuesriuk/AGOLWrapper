using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EsriUK.AGOLWrapper.Parameters
{
    public class PublishItemParameters : ParametersBase
    {
        public PublishItemParameters(string fileType)
        {
            switch (fileType)
            {
                case "serviceDefinition" :
                    break;
                
                case "shapefile" :
                    PublishParameters = new PublishParametersShapefile();
                    break;

                case "csv" :
                    //TODO create CSV publish params
                    break;
            }
            
            FileType = fileType;
        }

        public override Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> allParameters = base.GetParameters();
            
            allParameters.Add("PublishParameters", JsonConvert.SerializeObject(PublishParameters));

            return allParameters;
        }

        public string ItemId
        {
            get
            {
                string key = ValidateMethodName(System.Reflection.MethodBase.GetCurrentMethod().Name);
                string value = String.Empty;
                if (parameters.ContainsKey(key))
                {
                    value = parameters[key].ToString();
                }
                return value;
            }
            set
            {
                string key = ValidateMethodName(System.Reflection.MethodBase.GetCurrentMethod().Name);
                parameters[key] = value;
            }
        }
        public string FileType
        {
            get
            {
                string key = ValidateMethodName(System.Reflection.MethodBase.GetCurrentMethod().Name);
                string value = String.Empty;
                if (parameters.ContainsKey(key))
                {
                    value = parameters[key].ToString();
                }
                return value;
            }
            set
            {
                string key = ValidateMethodName(System.Reflection.MethodBase.GetCurrentMethod().Name);
                parameters[key] = value;
            }
        }
        public PublishParameters PublishParameters;
    }
}
