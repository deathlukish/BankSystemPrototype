using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation
{
    public static class JsonBase 
    {
        
        public static void SaveBase(ClassForLoad classForLoad, string Path)
        {

            JsonSerializerSettings setting = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All

            };
            var jsonString = JsonConvert.SerializeObject(classForLoad, Formatting.Indented, setting);
            //string json = JsonConvert.SerializeObject(_ClassForLoad);

            using (StreamWriter fs = new StreamWriter(Path))
            {
                fs.WriteLine(jsonString);
            }
        }

    

        public static ClassForLoad LoadDb(string Path)
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
            ClassForLoad clients = new ClassForLoad();
            using (StreamReader streamReader = new StreamReader(Path))
            {
                clients = JsonConvert.DeserializeObject<ClassForLoad> (streamReader.ReadToEnd(), setting);
            
            }
            return clients;

        }




    }
}
