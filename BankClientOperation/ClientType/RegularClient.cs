using BankClientOperation.AccountType;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BankClientOperation
{
    public class RegularClient : BaseClient, IBankAccount<RegularClient>
    {
        private ObservableCollection<BaseAccount<RegularClient>> _Accounts = new();
        public ObservableCollection<BaseAccount<RegularClient>> Accounts { get => _Accounts; set => _Accounts = value; }

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
            _Accounts.Add(account);
            _messageAction?.Invoke($"Открыт счет {account.NumAccount} для клиента {this.IdClient}");
        }

    }
}
