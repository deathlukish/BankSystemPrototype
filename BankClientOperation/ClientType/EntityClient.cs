using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation
{
    public class EntityClient:BaseClient
    {

        public EntityClient() : base()
        { 
        
        }


        public EntityClient(string First, string Middle, string Last, string Town):
            this(Guid.NewGuid(), First, Middle, Last, Town, null, true)
        {
            //this.IdClient = Guid.NewGuid();
            //this.IsActive = true;
            //this.First = First;
            //this.Middle = Middle;
            //this.Last = Last;
            //this.Town = Town;


        }
        public EntityClient(Guid IdClient, string First, string Middle, string Last, string Town, List<BaseAccount> Accounts, bool IsActive):
            base(IdClient, First, Middle, Last, Town, Accounts, IsActive)
        {
            //this.IdClient = IdClient;
            //this.IsActive = IsActive;
            //this.First = First;
            //this.Middle = Middle;
            //this.Last = Last;
            //this.Town = Town;
           

        }
    }
}
