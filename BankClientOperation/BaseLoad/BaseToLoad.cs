using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation.BaseLoad
{
    internal class BaseToLoad
    {
        public List<BaseClient> Clients { get; set; } = new List<BaseClient>();
        public List<BaseAccount> Accounts { get; set; } = new List<BaseAccount>();

    }
}
