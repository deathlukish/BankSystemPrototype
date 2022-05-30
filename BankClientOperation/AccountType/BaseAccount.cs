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
    public abstract class BaseAccount : INotifyPropertyChanged
    {
        private float _Balance;
        public int NumAccount { get; set; }
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
