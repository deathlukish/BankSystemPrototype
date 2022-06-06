using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation.AccountType
{
    interface IAccountContrVariant<R, in T>
        where R: BaseClient
        where T: BaseAccount<R>
    {
        public void TransAccountToAccount(T toAccount);
    }
}
