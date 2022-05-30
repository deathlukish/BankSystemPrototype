using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemPrototype
{
    public class Account
    {
        
        public int Num { get; set; }
        public long  Ballance { get; set; }
        public bool Deposite { get; set; }
        public Account(int Num, long Ballance, bool Deposite )
        {
            this.Num = Num;
            this.Ballance = Ballance;
            this.Deposite = Deposite;
        }

    }
}
