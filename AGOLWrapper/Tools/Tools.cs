using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

using EsriUK.AGOLWrapper;
using EsriUK.AGOLWrapper.Parameters;
using EsriUK.AGOLWrapper.Helpers;
using EsriUK.AGOLWrapper.Json;
using EsriUK.AGOLWrapper.Tools.Json;

using Newtonsoft.Json;

namespace EsriUK.AGOLWrapper.Tools
{
    public class Tools
    {
        public JsonArcGISServerResponse QueryArcGISServer(string server)
        {
            return QueryArcGISServer(server, String.Empty);
        }
        
        public JsonArcGISServerResponse QueryArcGISServer(string server, string folder)
        {
            //get the information from the AGS
            if (folder != String.Empty && !folder.EndsWith("/"))
            {
                folder += "/";
            }
            Uri url = new Uri(string.Format("{0}/{1}?f=json", server, folder));
            HttpPostRequest request = new HttpPostRequest(url);

            HttpWebResponse response = request.PostData();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            JsonArcGISServerResponse agsResponse = JsonConvert.DeserializeObject<JsonArcGISServerResponse>(sr.ReadToEnd());

            return agsResponse;
        }
    }
}
