using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsriUK.AGOLWrapper.Parameters
{
    public class CreateFolderParameters : ParametersBase
    {
        public override Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> allParameters = base.GetParameters();
            CommonParameters.GetParameters().ToList().ForEach(x => allParameters[x.Key] = x.Value);

            return allParameters;
        }

        public string Title
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
        public CommonParameters CommonParameters = new CommonParameters();
    }
}
