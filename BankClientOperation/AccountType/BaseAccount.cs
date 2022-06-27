using BankClientOperation.AccountType;
using Newtonsoft.Json;
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
    public abstract class BaseAccount<T> : INotifyPropertyChanged, IAccountContrVariant<T, BaseAccount<T>>
        where T:BaseClient        
    {
        protected Action<string> _messageAction;
        private float _Balance;
        public ulong NumAccount { get; set; }
        public float Balance 
        { 
            get => _Balance; 
            set => Set(ref _Balance, value);
        }
        [JsonIgnore]
        public Action<string> MessageAction
        {
            get => _messageAction;
            set => _messageAction = value;
        }
        public bool IsActive { get; set; } = true;
        public BaseAccount()
        { 
        
        }
        /// <summary>
        /// Снятие со счета
        /// </summary>
        /// <param name="moneyCount"></param>
        /// <returns></returns>
        public bool WithdrawMoney(float moneyCount)
        {
            if (Math.Abs(moneyCount) <= _Balance)
            {
                Balance -= Math.Abs(moneyCount);
                return true;
            }
            else
            {
                _messageAction?.Invoke($"Недостаточно средств на счете");
                return false;
            }

        }       
        /// <summary>
        /// Перевод между счетами
        /// </summary>
        /// <param name="toAccount"></param>
        /// <param name="Summ"></param>
        public void TransAccountToAccount(BaseAccount<T> toAccount, float Summ)
        {          
            if (toAccount != null)
            {
                if (this.WithdrawMoney(Summ))
                {
                    (toAccount as IAccountCovariant<T, BaseAccount<T>>).PutMoney(Summ);
                    _messageAction?.Invoke($"{Summ} переведено со счета {this.NumAccount} на счет {toAccount.NumAccount}");
                }
            }            
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnpropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        protected virtual bool Set<S>(ref S field, S value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnpropertyChanged(PropertyName);
            return true;

        }
    }
}
