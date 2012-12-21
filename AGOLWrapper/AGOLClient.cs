using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

using Newtonsoft.Json;

using EsriUK.AGOLWrapper.Helpers;
using EsriUK.AGOLWrapper.Parameters;
using Newtonsoft.Json.Linq;
using EsriUK.AGOLWrapper.Json;

namespace EsriUK.AGOLWrapper
{
    public class AGOLClient
    {
        public AGOLClient(UserCredentials credentials)
        {
            userCredentials = credentials;
        }
        private UserCredentials userCredentials;

        public string GenerateToken(TokenParameters tokenParams)
        {
            //TODO: config this URL
            Uri url = new Uri("https://www.arcgis.com/sharing/generateToken?f=json");
            HttpPostRequest request = new HttpPostRequest(url);
            request.AddFields(tokenParams.GetParameters());
            
            HttpWebResponse response = request.PostData();
            string token = JsonParser.ParseJson("token", response);

            //TODO: do this error-checking better
            if (String.IsNullOrWhiteSpace(token))
            {
                throw new Exception();
            }

            return token;
        }

        public bool IsServiceNameAvailable(ServiceNameParameters serviceNameParams)
        {
            //TODO: config this URL
            Uri url = new Uri("https://www.arcgis.com/sharing/generateToken?f=json");
            HttpPostRequest request = new HttpPostRequest(url);
            request.AddFields(serviceNameParams.GetParameters());

            HttpWebResponse response = request.PostData();
            string available = JsonParser.ParseJson("available", response);
            bool result = false;
            bool success = bool.TryParse(available, out result);

            //TODO: do this error-checking better
            if (!success)
            {
                throw new Exception();
            }

            return result;
        }

        public JsonAddItemResponse AddItem(AddItemParameters addItemParams, string token)
        {
            return AddItem(addItemParams, String.Empty, token);
        }
        public JsonAddItemResponse AddItem(AddItemParameters addItemParams, string folderId, string token)
        {
            try
            {
                if (folderId != String.Empty) folderId += "/";
                //TODO: figure out how to generate the URL //01a1484edcb14e0d99cb5b1266e9657b
                Uri url = new Uri(string.Format("http://www.arcgis.com/sharing/content/users/{0}/{1}addItem?f=json&token={2}", userCredentials.Username, folderId, token));
                HttpPostRequest request = new HttpPostRequest(url);

                if (addItemParams.File != String.Empty)
                {
                    request.AddFile("file", addItemParams.File, addItemParams.Filename);
                }
                request.AddFields(addItemParams.GetParameters());

                HttpWebResponse response = request.PostData();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                JsonAddItemResponse jsonAddItemResponse = JsonConvert.DeserializeObject<JsonAddItemResponse>(sr.ReadToEnd());

                //TODO: do this error-checking better
                if (!jsonAddItemResponse.success)
                {
                    throw new Exception();
                }

                return jsonAddItemResponse;

            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public JsonPublishResponse Publish(PublishItemParameters publishParams, string token)
        {
            try
            {
                //TODO: figure out how to generate the URL
                Uri url = new Uri(string.Format("http://www.arcgis.com/sharing/content/users/{0}/publish?f=json&token={1}", userCredentials.Username, token));
                HttpPostRequest request = new HttpPostRequest(url);

                request.AddFields(publishParams.GetParameters());

                HttpWebResponse response = request.PostData();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                JsonPublishResponse jsonPublishResponse = JsonConvert.DeserializeObject<JsonPublishResponse>(sr.ReadToEnd());

                bool result = false;
                bool parseSuccess = true; //TODO!! bool.TryParse(jsonPublishResponse.type, out result);

                //TODO: do this error-checking better
                if (!parseSuccess)
                {
                    throw new Exception();
                }

                return jsonPublishResponse;

            }

            catch (Exception e)
            {
                throw e;
            }
        }

        public JsonFolderResponse CreateFolder(CreateFolderParameters createFolderParams, string token)
        {
            //TODO: figure out how to generate the URL
            Uri url = new Uri(string.Format("http://www.arcgis.com/sharing/content/users/{0}/createFolder?f=json&token={1}", userCredentials.Username, token));
            HttpPostRequest request = new HttpPostRequest(url);

            request.AddFields(createFolderParams.GetParameters());

            HttpWebResponse response = request.PostData();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            JsonFolderResponse jsonCreateFolderResponse = JsonConvert.DeserializeObject<JsonFolderResponse>(sr.ReadToEnd());

            //TODO: do this error-checking better
            if (!jsonCreateFolderResponse.success)
            {
                throw new Exception();
            }

            return jsonCreateFolderResponse;
        }

        public JsonFolderResponse DeleteFolder(DeleteFolderParameters deleteFolderParams, string folderId, string token)
        {
            //TODO: figure out how to generate the URL
            Uri url = new Uri(string.Format("http://www.arcgis.com/sharing/content/users/{0}/{1}/delete?f=json&token={2}", userCredentials.Username, folderId, token));
            HttpPostRequest request = new HttpPostRequest(url);

            request.AddFields(deleteFolderParams.GetParameters());

            HttpWebResponse response = request.PostData();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            JsonFolderResponse jsonDeleteFolderResponse = JsonConvert.DeserializeObject<JsonFolderResponse>(sr.ReadToEnd());

            //TODO: do this error-checking better
            if (!jsonDeleteFolderResponse.success)
            {
                throw new Exception();
            }

            return jsonDeleteFolderResponse;
        }

        public JsonItem DeleteItem(DeleteItemParameters deleteItemParams, string itemId, string token)
        {
            //TODO: figure out how to generate the URL
            Uri url = new Uri(string.Format("http://www.arcgis.com/sharing/content/users/{0}/items/{1}/delete?f=json&token={2}", userCredentials.Username, itemId, token));
            HttpPostRequest request = new HttpPostRequest(url);

            request.AddFields(deleteItemParams.GetParameters());

            HttpWebResponse response = request.PostData();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            JsonItem jsonItem = JsonConvert.DeserializeObject<JsonItem>(sr.ReadToEnd());

            //TODO: do this error-checking better
            if (!jsonItem.success)
            {
                throw new Exception();
            }

            return jsonItem;
        }
    }
}
