using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BankClientOperation
{
    public class ClassForLoad
    {
       
        public List<BaseClient> Clients { get; set; }
        public List<BaseAccount> Accounts { get; set; }

    }
}
