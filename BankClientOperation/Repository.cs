using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BankClientOperation
{
    public class Repository
    {

        //JsonBase _JsonBase = new JsonBase();
        private ClassForLoad _ClientsBase = new ClassForLoad();



        public Repository()
        {
            _ClientsBase = JsonBase.LoadDb("./DB.json");
            if (_ClientsBase == null) _ClientsBase = new ClassForLoad();
            if (_ClientsBase.Clients == null) _ClientsBase.Clients = new List<BaseClient>();
            if (_ClientsBase.Accounts == null) _ClientsBase.Accounts = new List<BaseAccount>();

        }
        public List<BaseClient> GetClient()
        {
            List<BaseClient> ObsClients = new();
            foreach (var a in _ClientsBase.Clients)
            {
                ObsClients.Add(a);
            }

            return ObsClients;
        }
        public ObservableCollection<BaseAccount> GetAccountsFromClient(Guid OwnerId)
        {
            ObservableCollection<BaseAccount> ObsAccounts = new();
            foreach (var a in _ClientsBase.Accounts.FindAll(e => e.OwnerId == OwnerId))
            {
                ObsAccounts.Add(a);
            
            }
            return ObsAccounts;
        }
        public void OpenAccount(Guid OwnerID)
        {

            _ClientsBase.Accounts.Add(new Deposite(OwnerID, GenNumAccount(), 0));
            JsonBase.SaveBase(_ClientsBase, "./DB.json");
           

        }
        public void Replish(int NumAccount, float Sum)
        {

            _ClientsBase.Accounts.Find(e => e.NumAccount == NumAccount).Balance += Sum;
            JsonBase.SaveBase(_ClientsBase, "./DB.json");
        }

        public int GenNumAccount()
        {
            int NumAccount = 0;
            foreach (var a in _ClientsBase.Accounts)
            {
                if (a.NumAccount > NumAccount) NumAccount = a.NumAccount;
            
            }
            NumAccount++;
            return NumAccount;
        }
    }
}
