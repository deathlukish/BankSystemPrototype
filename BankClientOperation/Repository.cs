using BankClientOperation.AccountType;
using BankClientOperation.BaseLoad;
using BankClientOperation.ClientType;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BankClientOperation
{
    public class Repository
    {

        private List<BaseClient> _ClientsBase = new();
        private string _Path;
        public Repository(string Path)
        {
            _Path = Path;
            _ClientsBase = JsonBase.LoadDb(_Path);
            if (_ClientsBase == null) _ClientsBase = new List<BaseClient>();


        }

        public void AddAccount(BaseAccount<BaseClient> baseAccount)
        {
           // _ClientsBase.Accounts.Add(baseAccount);
        
        }

        public List<BaseClient> GetClient()
        {
            List<BaseClient> ObsClients = new();
            foreach (var a in _ClientsBase.Where(e => e.IsActive))
            {
                ObsClients.Add(a);
            }

            return ObsClients;
        }
        //public List<BaseClient> GetAccounts(Guid guid)
        //{
        //    List<BaseClient> ObsAccount = new();
        //    foreach (var a in _ClientsBase.Where(e => e.OwnerId == guid && e.IsActive))
        //    {
        //        ObsAccount.Add(a);
        //    }
        //    return ObsAccount;

        //}
        public void SaveBase()
        {
            JsonBase.SaveBase(_ClientsBase, _Path);

        }
        public void AddClient(ClientTypeEnum ClientType, string First, string Middle, string Last, string Town)
        {

            switch (ClientType)
            {
      
                case ClientTypeEnum.Entity:

                    _ClientsBase.Add(new EntityClient(First, Middle, Last, Town));
                    break;
                case ClientTypeEnum.Regular:
                    _ClientsBase.Add(new RegularClient( First, Middle, Last, Town));
                    break;
                case ClientTypeEnum.VIP:
                    _ClientsBase.Add(new VipClient(First, Middle, Last, Town));                  
                    break;

            }
            JsonBase.SaveBase(_ClientsBase, _Path);
        }
        public void OpenAccount(BaseAccount<BaseClient> Account, BaseClient client)
        {
          //  Account.NumAccount = GenIdAccount();
           // _ClientsBase.Accounts.Add(Account);
            //_ClientsBase[_ClientsBase.IndexOf(client)]
            //JsonBase.SaveBase(_ClientsBase, _Path);

        }
        //private long GenIdAccount()
        //{
        //    long Id = 100_000_000;
        //    foreach (var a in _ClientsBase.Accounts)
        //    {
        //        if (a.NumAccount > Id)
        //        {
        //            Id = a.NumAccount;
        //        }
        //    }
        //    Id++;
        //    return Id;
        //}

        public void CloseAccount(long NumAccount)
        {

           // _ClientsBase.Accounts.FirstOrDefault(e => e.NumAccount == NumAccount).IsActive = false;
            SaveBase();

        }
        public void ReplanishAccount(long NumAccount, float Sum)
        {

          //  _ClientsBase.Accounts.FirstOrDefault(e => e.NumAccount == NumAccount).Balance += Sum;
            SaveBase();
        }
        public ulong GenId()
        {
            
            ulong maxId = 0;
            foreach (var client in _ClientsBase)
            {
                if (client is IBankAccount<EntityClient>)
                {
                    if ((client as IBankAccount<EntityClient>).Accounts?.Count > 0)

                    {
                        ulong max = (client as IBankAccount<EntityClient>).Accounts?.Max(i => i.NumAccount) ?? 0;
                        maxId = maxId < max ? max : maxId;
                    }
                }
                if (client is IBankAccount<VipClient>)
                {
                    if ((client as IBankAccount<VipClient>).Accounts?.Count > 0)

                    {
                        ulong max = (client as IBankAccount<VipClient>).Accounts?.Max(i => i.NumAccount) ?? 0;
                        maxId = maxId < max ? max : maxId;
                    }
                }
                if (client is IBankAccount<RegularClient>)
                {
                    if ((client as IBankAccount<RegularClient>).Accounts?.Count > 0)

                    {
                        ulong max = (client as IBankAccount<RegularClient>).Accounts?.Max(i => i.NumAccount) ?? 0;
                        maxId = maxId < max ? max : maxId;
                    }
                }
            }
            return ++maxId;

        }




    }
}
