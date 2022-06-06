using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation
{
    public interface IWorkBase
    {

        abstract void LoadBase();
        public void SaveBase(ObservableCollection<BaseClient> collection);
        public void AddClient(BaseClient baseClient);

        public List<BaseClient> GetClients();
      //  public List<BaseAccount> GetAccounts(Guid IdClient);
       // public void AddAccount(BaseAccount baseAccount);

    }
}
