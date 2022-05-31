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
        //    int NumAccount = 0;
        //    foreach (var a in _ClientsBase.Accounts)
        //    {
        //        if (a.NumAccount > NumAccount) NumAccount = a.NumAccount;
            
        //    }
        //    NumAccount++;
        //    return NumAccount;
        //}
        public void AddClient(BaseClient ClientForSave)
        {


            _ClientsBase.Add(ClientForSave);
            JsonBase.SaveBase(_ClientsBase, "./DB.json");



        }
        public void SaveBase()
        {
            JsonBase.SaveBase(_ClientsBase, "./DB.json");

        }
    }
}
