using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EsriUK.AGOLWrapper;
using EsriUK.AGOLWrapper.Parameters;
using EsriUK.AGOLWrapper.Helpers;
using EsriUK.AGOLWrapper.Json;

namespace CreateItems
{
    class Program
    {
        static void Main(string[] args)
        {
            //ENTER CREDENTIALS
            userCreds.Username = "";
            userCreds.Password = "";
            userCreds.Referer = "";
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
                Console.WriteLine(string.Format("Processing {0}\n", arg));
                AddItemParameters addItemParams = new AddItemParameters();
                string[] names = arg.Split('/');
                string name = string.Format("{0} ({1})", names[names.Length - 2], names[names.Length - 1]);

                //TODO: create proper lookup to do this
                string type = String.Empty;
                switch (names[names.Length - 1].ToLower())
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
                }

                addItemParams.Url = arg;
                addItemParams.ItemInfoParameters.Type = type;
                addItemParams.Async = true;
                addItemParams.ItemInfoParameters.Title = name;
                addItemParams.ItemInfoParameters.Tags = "index";

                Console.WriteLine("Indexing service with ArcGIS Online\n");
                JsonAddItemResponse addItemResponse = client.AddItem(addItemParams, token);
                if (addItemResponse.success)
                {                    
                    Console.WriteLine(string.Format("Submitted {0}\nid {1}\n", addItemResponse.item, addItemResponse.id));
                }
                else
                {
                    Console.WriteLine(string.Format("Error indexing item {0}\n", addItemResponse.id));
                }

            }

            Console.WriteLine("\nPress Esc to quit");

            //press Esc to quit
            while (true)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape) break;
            }

        }

        private static string token;
        private static UserCredentials userCreds = new UserCredentials();
    }
}
