﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation.AccountType
{
    public interface IAccountCovariant<R, out T>
        where R: BaseClient
        where T: BaseAccount<R>
    {
       // T GetValue { get; }
        public void PutMoney(float Money);
    }
}
