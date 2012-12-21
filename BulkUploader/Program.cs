using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EsriUK.AGOLWrapper;
using EsriUK.AGOLWrapper.Parameters;
using EsriUK.AGOLWrapper.Helpers;
using EsriUK.AGOLWrapper.Json;

namespace BulkUploader
{
    class Program
    {
        static void Main(string[] args)
        {
            //ENTER CREDENTIALS
            #region credentials
            userCreds.Username = "";
            userCreds.Password = "";
            userCreds.Referer = "";
            #endregion
            //

            Console.WriteLine("Authenticating user\n");
            AGOLClient client = new AGOLClient(userCreds);

            TokenParameters tokenParams = new TokenParameters();
            tokenParams.Username = userCreds.Username;
            tokenParams.Password = userCreds.Password;
            tokenParams.Expiration = "540";
            tokenParams.Referer = userCreds.Referer;
            token = client.GenerateToken(tokenParams);

            foreach (string arg in args)
            {
                Console.WriteLine("Uploading shapefile");
                AddItemParameters addItemParams = new AddItemParameters();
                addItemParams.ItemInfoParameters.Type = "Shapefile";
                addItemParams.File = arg;
                string name = arg.Substring(arg.LastIndexOf('\\') + 1);
                addItemParams.Filename = name;

                addItemParams.Async = true;
                addItemParams.ItemInfoParameters.Title = name.Substring(0, name.Length-4);
                addItemParams.ItemInfoParameters.Tags = "bulkupload";

                JsonAddItemResponse addItemResponse = client.AddItem(addItemParams, token);
                if (addItemResponse.success)
                {
                    Console.WriteLine(string.Format("{0}\nid {1}\nPreparing item for publishing...\n", addItemResponse.item, addItemResponse.id));
                    StatusManager statusManager = new StatusManager(userCreds, token);
                    statusManager.CheckStatusCompletedEvent += new CheckStatusCompletedEventHandler(CheckStatusCompletedEventHandler);

                    Task t = statusManager.CheckStatusAsync(addItemResponse.id);
                }
                else
                {
                    Console.WriteLine(string.Format("Upload failed {0}\n", addItemResponse.id));
                }

            }

            //press Esc to quit
            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape) break;
            }
            
        }

        private static void CheckStatusCompletedEventHandler(object sender, StatusCompletedEventArgs e)
        {
            //  "status": "partial | processing | failed | completed"
            if (e.Response.status == "completed")
            {
                AGOLClient client = new AGOLClient(userCreds);

                Console.WriteLine(string.Format("Publishing Feature Service {0}\n", e.Response.itemId));
                PublishItemParameters publishParams = new PublishItemParameters("shapefile");
                publishParams.ItemId = e.Response.itemId;
                (publishParams.PublishParameters as PublishParametersShapefile).name = publishParams.ItemId;
                JsonPublishResponse publishResponse = client.Publish(publishParams, token);

                foreach (JsonServiceResponse serviceResponse in publishResponse.services)
                {
                    Console.WriteLine(string.Format("{0} published", serviceResponse.type));
                    Console.WriteLine(string.Format("{0}", serviceResponse.serviceItemId));
                    Console.WriteLine(string.Format("{0}\n", serviceResponse.serviceurl));
                }

                if (publishResponse.services.Length == 0)
                {
                    Console.WriteLine(string.Format("Service publishing failed\n"));
                }
            }
        }

        private static string token;
        private static UserCredentials userCreds = new UserCredentials();
    }
}
