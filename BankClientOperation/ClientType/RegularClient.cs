using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation
{
    public class RegularClient : BaseClient
    {

        public RegularClient() { }
        
        
        public RegularClient(string FirstName, string MiddleName, string LastName, string Town)
        {
            this.IdClient = Guid.NewGuid();
            this.IsActive = true;
            this.First= FirstName;
            this.Middle = MiddleName;
            this.Last = LastName;
            this.Town = Town;


        }
        public RegularClient(Guid IdClient,string FirstName, string MiddleName, string LastName, string Town)
        {
            this.IdClient = IdClient;
            this.IsActive = true;
            this.First = FirstName;
            this.Middle = MiddleName;
            this.Last = LastName;
            this.Town = Town;


        }
    }
}
