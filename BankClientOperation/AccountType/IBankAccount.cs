using System;
using System.Collections.Generic;
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
        /// <param name="account">счет клиента</param>
        /// <returns>рзультат выполнения / не выполнения команды</returns>
        public void AddAccount(BaseAccount<T> account);
        /// <summary>
        /// закрыть счет пользователя
        /// </summary>
        /// <param name="account">счет который требуется закрыть</param>
        /// <returns>рзультат выполнения / не выполнения команды</returns>
        public void RemoveAccount(BaseAccount<T> account);

        public List<BaseAccount<T>> Accounts { get; set; } 
    }
}
