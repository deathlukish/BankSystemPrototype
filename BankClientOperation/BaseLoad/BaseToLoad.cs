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
        public ObservableCollection<BaseClient> Clients { get; set; } = new ObservableCollection<BaseClient>();
        public ObservableCollection<BaseAccount<BaseClient>> Accounts { get; set; } = new ObservableCollection<BaseAccount<BaseClient>>();

    }
}
