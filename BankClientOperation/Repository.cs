using BankClientOperation.ClientType;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BankClientOperation
{
    public class Repository
    {

        private List<BaseClient> _ClientsBase = new();

        public Repository()
        {
            _ClientsBase = JsonBase.LoadDb("./DB.json");
            if (_ClientsBase == null) _ClientsBase = new List<BaseClient>();


        }
        public List<BaseClient> GetClient()
        {
            List<BaseClient> ObsClients = new();
            foreach (var a in _ClientsBase.FindAll(e => e.IsActive))
            {
                ObsClients.Add(a);
            }

            return ObsClients;
        }
        //public ObservableCollection<BaseAccount> GetAccountsFromClient(Guid OwnerId)
        //{
        //    ObservableCollection<BaseAccount> ObsAccounts = new();
        //    foreach (var a in _ClientsBase.Accounts.FindAll(e => e.OwnerId == OwnerId))
        //    {
        //        ObsAccounts.Add(a);

        //    }
        //    return ObsAccounts;
        //}
        //public void OpenAccount(Guid OwnerID)
        //{

        //    _ClientsBase.Add(new Deposite(OwnerID, GenNumAccount(), 0));
        //    JsonBase.SaveBase(_ClientsBase, "./DB.json");


        //}
        //public void Replish(int NumAccount, float Sum)
        //{

        //    _ClientsBase.Accounts.Find(e => e.NumAccount == NumAccount).Balance += Sum;
        //    JsonBase.SaveBase(_ClientsBase, "./DB.json");
        //}

        //public int GenNumAccount()
        //{
        //    int NumAccount = 100_000_000;
        //    foreach (var a in _ClientsBase.Accounts)
        //    {
        //        if (a.NumAccount > NumAccount) NumAccount = a.NumAccount;

        //    }
        //    NumAccount++;
        //    return NumAccount;
        //}
        //public void AddClient(BaseClient ClientForSave)
        //{


        //    _ClientsBase.Add(ClientForSave);
        //    JsonBase.SaveBase(_ClientsBase, "./DB.json");



        //}
        public void SaveBase()
        {
            JsonBase.SaveBase(_ClientsBase, "./DB.json");

        }
        public void AddClient(ClientTypeEnum ClientType, string First, string Middle, string Last, string Town)
        {
            //Guid guid = Guid.NewGuid();
            //List<BaseAccount> Accounts = new();
            //if (Deposite) Accounts.Add(new Deposite(guid));
            //if (NoDeposite) Accounts.Add(new NoDeposite(guid));

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
            JsonBase.SaveBase(_ClientsBase, "./DB.json");
        }

    }
}
