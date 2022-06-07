using BankClientOperation.AccountType;
using System;
using System.Collections.Generic;

namespace BankClientOperation
{
    public class RegularClient : BaseClient, IBankAccount<RegularClient>
    {
        private List<BaseAccount<RegularClient>> _Accounts = new();
        public List<BaseAccount<RegularClient>> Accounts { get => _Accounts; set => _Accounts = value; }

        public RegularClient() : base()
        {

        }


        public RegularClient(string First, string Middle, string Last, string Town) :
            this(Guid.NewGuid(), First, Middle, Last, Town, true)
        {


        }
        public RegularClient(Guid IdClient, string First, string Middle, string Last, string Town, bool IsActive) :
            base(IdClient, First, Middle, Last, Town, IsActive)
        {



        }

        public void AddAccount(BaseAccount<RegularClient> account)
        {
            throw new NotImplementedException();
        }

        public void RemoveAccount(BaseAccount<RegularClient> account)
        {
            throw new NotImplementedException();
        }
    }
}
