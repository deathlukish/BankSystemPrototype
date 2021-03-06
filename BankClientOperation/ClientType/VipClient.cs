using BankClientOperation.AccountType;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BankClientOperation
{
    public class VipClient : BaseClient, IBankAccount<VipClient>
    {       
        private ObservableCollection<BaseAccount<VipClient>> _Accounts = new();
        public ObservableCollection<BaseAccount<VipClient>> Accounts { get => _Accounts; set => _Accounts = value; }
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
            _Accounts.Add(account);
            _messageAction?.Invoke($"Открыт счет {account.NumAccount} для клиента {this.IdClient}");
        }

    }
}
