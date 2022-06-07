using BankClientOperation.AccountType;
using System;
using System.Collections.Generic;

namespace BankClientOperation
{
    public class EntityClient : BaseClient, IBankAccount<EntityClient>
    {
        private List<BaseAccount<EntityClient>> _Accounts = new List<BaseAccount<EntityClient>>();
        public List<BaseAccount<EntityClient>> Accounts { get => _Accounts; set => _Accounts = value; }
  
        public EntityClient() : base()
        {

        }
        public EntityClient(string First, string Middle, string Last, string Town):
            this(Guid.NewGuid(), First, Middle, Last, Town, true)
        {


        }
        public EntityClient(Guid IdClient, string First, string Middle, string Last, string Town, bool IsActive):
            base(IdClient, First, Middle, Last, Town, IsActive)
        {


        }

        public void AddAccount(BaseAccount<EntityClient> account)
        {
            throw new NotImplementedException();
        }

        public void RemoveAccount(BaseAccount<EntityClient> account)
        {
            throw new NotImplementedException();
        }
    }
}
