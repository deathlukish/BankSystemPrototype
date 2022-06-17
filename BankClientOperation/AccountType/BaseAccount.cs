using BankClientOperation.AccountType;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankClientOperation
{
    public abstract class BaseAccount<S> : INotifyPropertyChanged, IAccountContrVariant<S, BaseAccount<S>>
        where S:BaseClient
        
    {
        private float _Balance;
        public ulong NumAccount { get; set; }
        public Guid OwnerId { get; set; }
        public float Balance 
        { 
            get => _Balance; 
            set => Set(ref _Balance, value);
        }
        public bool IsActive { get; set; } = true;


        public BaseAccount()
        { 
        
        }
        public bool WithdrawMoney(float moneyCount)
        {
            if (Math.Abs(moneyCount) <= _Balance)
            {
                Balance -= Math.Abs(moneyCount);
                return true;
            }
            else
            {
                return false;
            }

        }
        

        public void TransAccountToAccount(BaseAccount<S> toAccount, float Summ)
        {
           
            if (toAccount != null)
            {
                if (this.WithdrawMoney(Summ))
                {
                    (toAccount as IAccountCovariant<S, BaseAccount<S>>).PutMoney(Summ);
                }
            }

            
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnpropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnpropertyChanged(PropertyName);
            return true;

        }
    }
}
