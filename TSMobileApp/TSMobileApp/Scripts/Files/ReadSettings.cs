using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TSMobileApp.Scripts.Files
{
    class ReadSettings
    {
        private static readonly string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "net.json");
        public static bool CheckIfConfigExists()
        {
            
            if (!File.Exists(filename))
            {
                Console.WriteLine("IO: (ERR) Failed to find settings file!");
                return false;
            }
            else
            {
                Console.WriteLine("IO: Settings file located!");
                return true;
            }
        }

        public static void UpdateConfigFile(string server, string port)
        {
            Objects.NetSettings net_settings = new Objects.NetSettings();
            net_settings.Server_Addr = server;
            net_settings.Server_Port = port;

            string json_str = JsonConvert.SerializeObject(net_settings);
            File.WriteAllText(filename, json_str);

            Console.WriteLine(File.ReadAllText(filename));
        }

        public static List<string> ReadFromConfigFile()
        {
            List<string> server_data = new List<string>();
            using (StreamReader reader = File.OpenText(filename))
            {
                JObject o = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                foreach (JProperty property in o.Properties())
                {
                    server_data.Add(property.Value.ToString());
                }
            }

            return server_data;
        }
    }
}