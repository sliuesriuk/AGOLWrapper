using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EsriUK.AGOLWrapper;
using EsriUK.AGOLWrapper.Parameters;
using EsriUK.AGOLWrapper.Helpers;
using System.Threading.Tasks;
using EsriUK.AGOLWrapper.Json;

namespace EsriUK.AGOLWrapperTest
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                #region credentials
                //ENTER CREDENTIALS
                userCreds.Username = "";
                userCreds.Password = "";
                userCreds.Referer = "";
                #endregion
                //

                Console.WriteLine("Authenticating user");
                AGOLClient client = new AGOLClient(userCreds);

                TokenParameters tokenParams = new TokenParameters();
                tokenParams.Username = userCreds.Username;
                tokenParams.Password = userCreds.Password;
                tokenParams.Expiration = "540";
                tokenParams.Referer = userCreds.Referer;
                token = client.GenerateToken(tokenParams);

                string file = args[0];
                string filename = file.Substring(file.LastIndexOf('\\') + 1);

                Console.WriteLine("Uploading shapefile");
                AddItemParameters addItemParams = new AddItemParameters();
                addItemParams.ItemInfoParameters.Type = "Shapefile";
                addItemParams.File = file;
                addItemParams.Filename = filename;

                addItemParams.Async = true;
                addItemParams.ItemInfoParameters.Title = filename.Substring(0, filename.Length - 4);
                addItemParams.ItemInfoParameters.Tags = filename.Substring(0, filename.Length - 4);

                JsonAddItemResponse addItemResponse = client.AddItem(addItemParams, token);
                if (addItemResponse.success)
                {
                    Console.WriteLine(string.Format("{0}\n", addItemResponse.id));

                    Console.WriteLine("Preparing item for publishing...");
                    StatusManager statusManager = new StatusManager(userCreds, token);
                    statusManager.CheckStatusCompletedEvent += new CheckStatusCompletedEventHandler(CheckStatusCompletedEventHandler);

                    //TODO: make a synchronous version of CheckStatus(), in case the user wants a blocking call
                    Task t = statusManager.CheckStatusAsync(addItemResponse.id);
                }
                else
                {
                    Console.WriteLine(string.Format("Upload failed {0}\n", addItemResponse.id));
                }
            }
            else
            {
                Console.WriteLine("Please specify a shapefile as an input parameter at runtime");
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

                Console.WriteLine("Publishing Feature Service");
                PublishItemParameters publishParams = new PublishItemParameters("shapefile");
                publishParams.ItemId = e.Response.itemId;
                (publishParams.PublishParameters as PublishParametersShapefile).name = "Myservicetest";
                (publishParams.PublishParameters as PublishParametersShapefile).description = "My service description";
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

            Console.WriteLine("\nPress Esc to quit");
        }

        private static string token;
        private static UserCredentials userCreds = new UserCredentials();
    }
}
