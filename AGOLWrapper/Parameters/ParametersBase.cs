using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EsriUK.AGOLWrapper.Parameters
{
    public abstract class ParametersBase
    {
        public virtual Dictionary<string, string> GetParameters()
        {
            return parameters;
        }

        protected string ValidateMethodName(string key)
        {
            if (key.Contains("_"))
            {
                key = key.Substring(key.LastIndexOf("_") + 1);
            }

            return key;
        }

        protected Dictionary<string, string> parameters = new Dictionary<string,string>();
    }
}
