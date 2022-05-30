using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation
{
    public class VipClient:BaseClient
    {

        public VipClient() { }
        public VipClient(string FirstName, string MiddleName, string LastName, string Town)

        {
            this.IdClient = Guid.NewGuid();
            this.First = FirstName;
            this.Middle = MiddleName;
            this.Last = LastName;
            this.Town = Town;
           

        }
        public VipClient(Guid IdClient, string FirstName, string MiddleName, string LastName, string Town)

        {
            this.IdClient = IdClient;
            this.First = FirstName;
            this.Middle = MiddleName;
            this.Last = LastName;
            this.Town = Town;
           

        }

    }
}
