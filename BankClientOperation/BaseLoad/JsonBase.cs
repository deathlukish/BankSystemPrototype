using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BankClientOperation
{
    internal static class JsonBase 
    {
        /// <summary>
        /// Сохранить базу
        /// </summary>
        /// <param name="baseClients"></param>
        /// <param name="Path"></param>
        public static void SaveBase(List<BaseClient> baseClients, string Path)
        {
            List<BaseClient> clients = new();
            JsonSerializerSettings setting = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All

            };
            var jsonString = JsonConvert.SerializeObject(baseClients, Formatting.Indented, setting);
            using (StreamWriter fs = new StreamWriter(Path))
            {
                fs.WriteLine(jsonString);
            }
        }   
        /// <summary>
        /// Загрузить базу
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static List<BaseClient> LoadDb(string Path)
        {
            if (!File.Exists(Path))
            {
                using (FileStream fs = File.Create(Path))
                {

                }
            }
            JsonSerializerSettings setting = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All

            };
            List<BaseClient>  clients = new();
            using (StreamReader streamReader = new StreamReader(Path))
            {
                clients = JsonConvert.DeserializeObject<List<BaseClient>>(streamReader.ReadToEnd(), setting);
            
            }
            return clients;

        }




    }
}
