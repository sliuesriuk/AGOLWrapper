using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace EsriUK.AGOLWrapper.Parameters
{
    public class AddItemParameters : ParametersBase
    {
        public override Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> allParameters = base.GetParameters();
            ItemInfoParameters.GetParameters().ToList().ForEach(x => allParameters[x.Key] = x.Value);

            return allParameters;
        }
       
        public string File
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
        public string Url
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
        public string Text
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
        public string RelationshipType
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
        public string OriginItemId
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
        public string DestinationItemId
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
        public bool Async
        {
            get
            {
                string key = ValidateMethodName(System.Reflection.MethodBase.GetCurrentMethod().Name);
                bool value = true;
                if (parameters.ContainsKey(key))
                {
                    bool.TryParse(parameters[key].ToString(), out value);
                }
                return value;
            }
            set
            {
                string key = ValidateMethodName(System.Reflection.MethodBase.GetCurrentMethod().Name);
                parameters[key] = value.ToString();
            }
        }
        public bool Multipart
        {
            get
            {
                string key = ValidateMethodName(System.Reflection.MethodBase.GetCurrentMethod().Name);
                bool value = true;
                if (parameters.ContainsKey(key))
                {
                    bool.TryParse(parameters[key].ToString(), out value);
                }
                return value;
            }
            set
            {
                string key = ValidateMethodName(System.Reflection.MethodBase.GetCurrentMethod().Name);
                parameters[key] = value.ToString();
            }
        }
        public string Filename
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
        public ItemInfoParameters ItemInfoParameters = new ItemInfoParameters();
    }
}
