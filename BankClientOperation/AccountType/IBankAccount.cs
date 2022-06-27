using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation.AccountType
{

    public interface IBankAccount<T>
       where T : BaseClient
    {
        /// <summary>
        /// добавить счет клиента
        /// </summary>
        public void AddAccount(BaseAccount<T> account);

        public ObservableCollection<BaseAccount<T>> Accounts { get; set; } 
    }
}
