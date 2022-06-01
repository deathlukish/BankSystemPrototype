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

        public void SaveBase()
        {
            JsonBase.SaveBase(_ClientsBase, "./DB.json");

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
            JsonBase.SaveBase(_ClientsBase, "./DB.json");
        }

    }
}
