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
        //string _path = "./DB.json";
        //List<BaseClient> _Clients = new List<BaseClient>();
        //List<BaseAccount> _Accounts = new List<BaseAccount>();
        //ClassForLoad _ClassForLoad;
        //public JsonBase()
        //{
        //   // LoadBase();
        
        //}
        //public List<BaseAccount> GetAccounts(Guid IdClient)
        //{
        //    return _Accounts.FindAll(e => e.OwnerId == IdClient && e.IsActive);
        //}

        //public List<BaseClient> GetClients()
        //{
        //    return _Clients.FindAll(e => e.IsActive);
        //}

        //public void LoadBase()
        //{
        //    if (!File.Exists(_path))
        //    {
        //        using (FileStream fs = File.Create(_path))
        //        {

        //        }
        //    }
        //    using (StreamReader sr = new StreamReader(_path))
        //    {

        //        _ClassForLoad = JsonConvert.DeserializeObject<ClassForLoad>(sr.ReadToEnd());


        //    }
        //    if (_ClassForLoad == null)
        //    { 
        //        _ClassForLoad = new ClassForLoad();
        //        _ClassForLoad.Clients = new List<BaseClient>();
        //        _ClassForLoad.Accounts = new List<BaseAccount>();
        //    }
        //    foreach (var a in _ClassForLoad.Clients)
        //    {
        //        switch (a.ClientType)
        //        {
        //            case (int)CliType.Entity:
        //                _Clients.Add(new EntityClient(a.IdClient,a.First,a.Middle,a.Last,a.Town,a.IsActive, null));
        //                break;
        //            case (int)CliType.Regular:
        //                _Clients.Add(new RegularClient(a.IdClient,a.First, a.Middle, a.Last, a.Town));
        //                break;
        //            case (int)CliType.Vip:
        //                _Clients.Add(new VipClient(a.IdClient, a.First, a.Middle, a.Last, a.Town));
        //                break;
        //        }

            
        //    }
        //    foreach (var a in _ClassForLoad.Accounts)
        //    {
               
        //        switch (a.TypeAccount)
        //        {
        //            case (int)AccType.Deposite:
        //                _Accounts.Add(new Deposite(a.OwnerId, a.NumAccount, a.Balance));
        //                break;
        //            case (int)AccType.NoDeposite:
        //                _Accounts.Add(new NoDeposite(a.OwnerId, a.NumAccount, a.Balance));
        //                break;
                
        //        }
                 
            
        //    }

        //}

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

        //public void AddClient(BaseClient baseClient)
        //{
        //    _ClassForLoad.Clients.Add((BaseClient)baseClient);
        //    SaveBase();
        //}
        //public void AddAccount(BaseAccount baseAccount)
        //{
        //    baseAccount.NumAccount = GenId();
        //    _ClassForLoad.Accounts.Add((BaseAccount)baseAccount);
        //    SaveBase();

        //}

        //private int GenId()
        //{
        //    int NumAccount = 0;
        //    foreach (var a in _ClassForLoad.Accounts)
        //    {
        //        if (a.NumAccount > NumAccount) NumAccount = a.NumAccount;
        //    }
        //    NumAccount++;
        //    return NumAccount;
        //}

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
