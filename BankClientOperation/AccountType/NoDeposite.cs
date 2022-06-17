﻿using BankClientOperation.AccountType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation
{
    public class NoDeposite<T> : BaseAccount<T>, IAccountCovariant<T, BaseAccount<T>>
        where T: BaseClient
    {
        public NoDeposite() { }       
        public NoDeposite(Guid OwnerId, ulong Num, float Balance)
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
        public NoDeposite(Guid guid, ulong Num) : this(guid, Num, 0)
        {
            this.IsActive = true;
        }

        public void PutMoney(float Money)
        {
            Balance += Money;
        }
    }
}