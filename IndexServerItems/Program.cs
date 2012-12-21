using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EsriUK.AGOLWrapper;
using EsriUK.AGOLWrapper.Parameters;
using EsriUK.AGOLWrapper.Helpers;
using EsriUK.AGOLWrapper.Json;
using EsriUK.AGOLWrapper.Tools.Json;
using EsriUK.AGOLWrapper.Tools;

namespace IndexServerItems
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

            //create all the content
            foreach (string arg in args)
            {
                Console.WriteLine(string.Format("Processing {0}\n", arg));
                QueryArcGISServer(arg, String.Empty, null);
            }
            
            Console.WriteLine("\nPress Enter to delete all services");

            //press Enter to continue
            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter) break;
            }

            Console.WriteLine("Deleting...");

            //delete all the content again
            foreach (string folder in folderIds)
            {
                JsonFolderResponse response = client.DeleteFolder(new DeleteFolderParameters(), folder, token);
                if (response.success)
                {
                    Console.WriteLine(string.Format("Folder {0} {1}", response.folder.title, response.folder.id));
                }
                else
                {
                    Console.WriteLine(string.Format("Error {0}", response.folder.title));
                    Console.WriteLine(string.Format("{0}\n", response.folder.id));
                }
            }
            foreach (string item in itemIds)
            {
                JsonItem response = client.DeleteItem(new DeleteItemParameters(), item, token);
                if (response.success)
                {
                    Console.WriteLine(string.Format("Item {0}", response.itemId));
                }
                else
                {
                    Console.WriteLine(string.Format("Error {0}\n", response.itemId));
                }
            }

            Console.WriteLine("\nPress Esc to quit");

            //press Esc to quit
            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape) break;
            }

        }

        private static void QueryArcGISServer(string server, string directory, JsonFolderResponse parentDirectory)
        {
            Tools tools = new Tools();
            JsonArcGISServerResponse agsResponse = tools.QueryArcGISServer(server, directory);
            foreach (string folder in agsResponse.folders)
            {
                Console.WriteLine(string.Format("====================\n\nCreating folder: {0}", folder));
                CreateFolderParameters folderParams = new CreateFolderParameters();
                folderParams.Title = folder;
                AGOLClient client = new AGOLClient(userCreds);
                JsonFolderResponse response = client.CreateFolder(folderParams, token);
                folderIds.Add(response.folder.id);
                
                //recursive
                Console.WriteLine(string.Format("Recursing {0} for services\n\n", folder));
                QueryArcGISServer(server, folder, response);
            }
            foreach (JsonArcGISServerService service in agsResponse.services)
            {
                Console.WriteLine(string.Format("Indexing service {0}", service.name));

                AddItemParameters addItemParams = new AddItemParameters();

                //TODO: create proper lookup to do this
                string type = String.Empty;
                switch (service.type.ToLower())
                {
                    case "featureserver":
                        type = "Feature Service";
                        break;
                    case "mapserver":
                        type = "Map Service";
                        break;
                    case "imageserver":
                        type = "Image Service";
                        break;
                    case "gpserver":
                        type = "Geoprocessing Service";
                        break;
                    case "geometryserver":
                        type = "Geometry Service";
                        break;
                    case "geocodeserver":
                        type = "Geocoding Service";
                        break;
                }

                if (!server.EndsWith("/")) server += "/";

                addItemParams.Url = String.Format("{0}{1}/{2}", server, service.name, service.type);
                addItemParams.ItemInfoParameters.Type = type;
                addItemParams.Async = true;
                addItemParams.ItemInfoParameters.Title = directory == String.Empty ? service.name : service.name.Substring(directory.Length+1);
                addItemParams.ItemInfoParameters.Tags = "bulkindex";

                AGOLClient client = new AGOLClient(userCreds);
                JsonAddItemResponse addItemResponse = null;
                if (parentDirectory == null)
                {
                    addItemResponse = client.AddItem(addItemParams, token);
                    itemIds.Add(addItemResponse.id);
                }
                else
                {
                    addItemResponse = client.AddItem(addItemParams, parentDirectory.folder.id, token);
                }

                Console.WriteLine(string.Format("Completed {0}\n", addItemResponse.item));
            }
        }

        private static string token;
        private static UserCredentials userCreds = new UserCredentials();
        private static List<string> folderIds = new List<string>();
        private static List<string> itemIds = new List<string>();
    }
}
