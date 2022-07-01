using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation
{
    public  class ExcessSumExeption : Exception
    {
        public override string Message => "Превышена сумма перевода (лимит 10000)";
    }
}
