﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation
{
    public class EntityClient:BaseClient
    {
        private List<BaseAccount<EntityClient>> _Accounts;
        public EntityClient() : base()
        { 
        
        }
        public List<BaseAccount<EntityClient>> Accounts { get => _Accounts; set => _Accounts = value; }

        public EntityClient(string First, string Middle, string Last, string Town):
            this(Guid.NewGuid(), First, Middle, Last, Town, true)
        {
            //this.IdClient = Guid.NewGuid();
            //this.IsActive = true;
            //this.First = First;
            //this.Middle = Middle;
            //this.Last = Last;
            //this.Town = Town;


        }
        public EntityClient(Guid IdClient, string First, string Middle, string Last, string Town, bool IsActive):
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
