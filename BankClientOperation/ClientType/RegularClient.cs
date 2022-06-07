using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation
{

    public class RegularClient : BaseClient
    {

        private List<BaseAccount<RegularClient>> _Accounts;

        public List<BaseAccount<RegularClient>> Accounts { get => _Accounts; set => _Accounts = value; }
        public RegularClient() : base()
        {

        }


        public RegularClient(string First, string Middle, string Last, string Town) :
            this(Guid.NewGuid(), First, Middle, Last, Town, true)
        {
            //this.IdClient = Guid.NewGuid();
            //this.IsActive = true;
            //this.First = First;
            //this.Middle = Middle;
            //this.Last = Last;
            //this.Town = Town;


        }
        public RegularClient(Guid IdClient, string First, string Middle, string Last, string Town, bool IsActive) :
            base(IdClient, First, Middle, Last, Town, IsActive)
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
