using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EsriUK.AGOLWrapper.Parameters
{
    public class TokenParameters : ParametersBase
    {
        public string Username
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
        public string Password
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
        public string Expiration
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
        public string Referer
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
