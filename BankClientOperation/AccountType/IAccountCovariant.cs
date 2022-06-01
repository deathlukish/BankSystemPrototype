﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation.AccountType
{
    interface IAccountCovariant<R, out T>
        where R: BaseClient
        where T: BaseAccount
    {

        public void PutMoney(double Money);
    }
}