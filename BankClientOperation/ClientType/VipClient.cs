using BankClientOperation.AccountType;
using System;
using System.Collections.Generic;

namespace BankClientOperation
{
    public class VipClient : BaseClient, IBankAccount<VipClient>
    {       
        private List<BaseAccount<VipClient>> _Accounts = new();
        public List<BaseAccount<VipClient>> Accounts { get => _Accounts; set => _Accounts = value; }
        public override bool IsCanChange { get; set; } = false;

        public VipClient() : base()
        {

        }

        public VipClient(string First, string Middle, string Last, string Town) :
            this(Guid.NewGuid(), First, Middle, Last, Town, true)
        {


        }
        public VipClient(Guid IdClient, string First, string Middle, string Last, string Town,  bool IsActive) :
            base(IdClient, First, Middle, Last, Town, IsActive)
        {

        }

        public void AddAccount(BaseAccount<VipClient> account)
        {
            throw new NotImplementedException();
        }

        public void RemoveAccount(BaseAccount<VipClient> account)
        {
            throw new NotImplementedException();
        }
    }
}
