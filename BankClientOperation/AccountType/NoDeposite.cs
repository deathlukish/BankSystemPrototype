using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation
{
    public class NoDeposite : BaseAccount<BaseClient>
    {

        public NoDeposite() { }
        
        public NoDeposite(Guid OwnerId, int Num, float Balance)
        {

            this.OwnerId = OwnerId;
            this.NumAccount = Num;
            this.Balance = Balance;



        }

        public NoDeposite(Guid OwnerId) : this(OwnerId,0,0)
        {
            this.IsActive = true;
            this.NumAccount = NumAccount;

        }


    }
}