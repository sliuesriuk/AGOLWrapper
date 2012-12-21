using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsriUK.AGOLWrapper.Parameters
{
    public class SpatialReference : ParametersBase
    {

        public int Wkid
        {
            get
            {
                string key = ValidateMethodName(System.Reflection.MethodBase.GetCurrentMethod().Name);
                int value = 102100;
                if (parameters.ContainsKey(key))
                {
                    int.TryParse(parameters[key].ToString(), out value);
                }
                return value;
            }
            set
            {
                string key = ValidateMethodName(System.Reflection.MethodBase.GetCurrentMethod().Name);
                parameters[key] = value.ToString();
            }
        }
    }
}
