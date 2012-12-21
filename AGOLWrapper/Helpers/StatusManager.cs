using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EsriUK.AGOLWrapper.Json;
using EsriUK.AGOLWrapper.Parameters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EsriUK.AGOLWrapper.Helpers
{
    public delegate void CheckStatusCompletedEventHandler(object sender, StatusCompletedEventArgs e);

    public class StatusCompletedEventArgs
    {
        public StatusCompletedEventArgs(JsonStatusResponse response)
        {
            _response = response;
        }

        //return an object representation of the JSON response {"status" : "completed","statusMessage" : "completed","itemId" : "99aa3416340c4c91989b1af6c5453ce2"}
        public JsonStatusResponse Response { get { return _response; } }
        private JsonStatusResponse _response;
    }

    public class StatusManager
    {
        public event CheckStatusCompletedEventHandler CheckStatusCompletedEvent;

        public StatusManager(UserCredentials userCredentials, string token)
        {
            _userCredentials = userCredentials;
            _token = token;
        }

        public async Task CheckStatusAsync(string itemId)
        {
            //call Portal API and poll for updates
            HttpClient httpClient = new HttpClient();
            JsonStatusResponse jsonStatusResponse = null;
            string status = null;
            while (status != "completed")
            {
                string response = await httpClient.GetStringAsync(string.Format("http://www.arcgis.com/sharing/content/users/{0}/items/{1}/status?f=json&token={2}", _userCredentials.Username, itemId, _token));
                jsonStatusResponse = JsonConvert.DeserializeObject<JsonStatusResponse>(response);
                status = jsonStatusResponse.status;
                await Task.Delay(1000);
            }

            //raise event to return response
            StatusCompletedEventArgs e = new StatusCompletedEventArgs(jsonStatusResponse);
            CheckStatusCompletedEvent(this, e);
        }

        private UserCredentials _userCredentials;
        private string _token;
        
    }
}
