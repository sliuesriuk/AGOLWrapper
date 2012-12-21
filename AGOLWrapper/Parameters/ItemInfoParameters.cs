using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EsriUK.AGOLWrapper.Parameters
{
    public class ItemInfoParameters : ParametersBase
    {
        public string Access
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
                //TODO: validate against the enum?!
                //AccessType accessType = (AccessType)System.Enum.Parse(typeof(AccessType), value);
                
                parameters[key] = value;
            }
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
        public string Thumbnail
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
        public string ThumbnailUrl
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
        public string Metadata
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
        public string TypeKeywords
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
        public string Description
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
        public string Tags
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
        public string Snippet
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
        public string Extent
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
        public string SpatialReference
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
        public string AccessInformation
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
        public string LicenseInfo
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
        public string Culture
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

        private enum AccessType { PRIVATE, SHARED, ORG, PUBLIC };
    }
}
