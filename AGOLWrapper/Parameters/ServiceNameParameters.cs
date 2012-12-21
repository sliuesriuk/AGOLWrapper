using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EsriUK.AGOLWrapper.Parameters
{
    public class ServiceNameParameters : ParametersBase
    {
        public string Name
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
        public string Type
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
    }
}
