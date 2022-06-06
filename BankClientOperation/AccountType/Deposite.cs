using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation
{
    public class Deposite : BaseAccount<BaseClient>
    {

        public Deposite() : base()
        { 
        
        }
        
        
        public Deposite(Guid OwnerId, int Num, float Balance)
        {
            
            this.OwnerId = OwnerId;
            this.NumAccount = Num;
            this.Balance = Balance;

        }

        public Deposite(Guid OwnerId) : this(OwnerId, 0, 0)
        {

            this.IsActive = true;


        }

    }
}
