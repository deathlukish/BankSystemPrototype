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


        public EntityClient(string FirstName, string MiddleName, string LastName, string Town)
        {
            this.IdClient = Guid.NewGuid();
            this.IsActive = true;
            this.First = FirstName;
            this.Middle = MiddleName;
            this.Last = LastName;
            this.Town = Town;


        }
        public EntityClient(Guid IdClient, string First, string Middle, string Last, string Town, bool IsActive)
        {
            this.IdClient = IdClient;
            this.IsActive = IsActive;
            this.First = First;
            this.Middle = Middle;
            this.Last = Last;
            this.Town = Town;
           

        }
    }
}
