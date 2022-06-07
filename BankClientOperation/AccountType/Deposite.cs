using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation
{
    public class Deposite<T> : BaseAccount<T>
        where T: BaseClient
    {

        public Deposite() : base()
        { 
        
        }
        
        
        public Deposite(Guid OwnerId, ulong Num, float Balance)
        {
            
            this.OwnerId = OwnerId;
            this.NumAccount = Num;
            this.Balance = Balance;

        }

        public Deposite(Guid guid,ulong Num) : this(guid,Num, 0)
        {

            this.IsActive = true;


        }

    }
}
