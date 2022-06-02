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

        private BaseToLoad _ClientsBase = new();

        public Repository()
        {
            _ClientsBase = JsonBase.LoadDb("./DB.json");
            if (_ClientsBase == null) _ClientsBase = new BaseToLoad();


        }

        public void AddAccount(BaseAccount baseAccount)
        {
            _ClientsBase.Accounts.Add(baseAccount);
        
        }

        public ObservableCollection<BaseClient> GetClient()
        {
            ObservableCollection<BaseClient> ObsClients = new();
            foreach (var a in _ClientsBase.Clients.Where(e => e.IsActive))
            {
                ObsClients.Add(a);
            }

            return ObsClients;
        }
        public ObservableCollection<BaseAccount> GetAccounts(Guid guid)
        {
            ObservableCollection<BaseAccount> ObsAccount = new();
            foreach (var a in _ClientsBase.Accounts.Where(e => e.OwnerId == guid && e.IsActive))
            {
                ObsAccount.Add(a);
            }
            return ObsAccount;

        }
        public void SaveBase()
        {
            JsonBase.SaveBase(_ClientsBase, "./DB.json");

        }
        public void AddClient(ClientTypeEnum ClientType, string First, string Middle, string Last, string Town)
        {

            switch (ClientType)
            {
      
                case ClientTypeEnum.Entity:

                    _ClientsBase.Clients.Add(new EntityClient(First, Middle, Last, Town));
                    break;
                case ClientTypeEnum.Regular:
                    _ClientsBase.Clients.Add(new RegularClient( First, Middle, Last, Town));
                    break;
                case ClientTypeEnum.VIP:
                    _ClientsBase.Clients.Add(new VipClient(First, Middle, Last, Town));                  
                    break;

            }
            JsonBase.SaveBase(_ClientsBase, "./DB.json");
        }
        public void OpenAccount<A>(A Account) where A : BaseAccount
        {
            Account.NumAccount = GenIdAccount();
            _ClientsBase.Accounts.Add(Account);
            JsonBase.SaveBase(_ClientsBase, "./DB.json");

        }
        private int GenIdAccount()
        {
            int Id = 0;
            foreach (var a in _ClientsBase.Accounts)
            {
                if (a.NumAccount > Id)
                {
                    Id = a.NumAccount++;
                }
            }
            return Id;
        }

    }
}
