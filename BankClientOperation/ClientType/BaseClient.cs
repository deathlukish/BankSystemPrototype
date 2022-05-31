
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BankClientOperation 
{
    public abstract class BaseClient : INotifyPropertyChanged
    {
        private string _First;
        private string _Middle;
        private string _Last;
        private string _Town;
        private bool _IsActive;
        private List<BaseAccount> _Accounts;
        public Guid IdClient { get; set; }
        public string First { get => _First; set => Set(ref _First, value); }
        public string Middle { get => _Middle; set => Set(ref _Middle, value); }
        public string Last { get => _Last; set => Set(ref _Last, value); }
        public  string Town { get => _Town; set => Set(ref _Town, value); }
        public bool IsActive { get => _IsActive; set => Set(ref _IsActive, value); }
        public List<BaseAccount> Accounts { get => _Accounts; set => Set(ref _Accounts, value); }

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
        public BaseClient()
        {
        
        
        }
        public BaseClient(Guid IdClient, string First, string Middle, string Last, string Town, List<BaseAccount> Accounts, bool IsActive)
        {
            this.IdClient = IdClient;
            this.IsActive = IsActive;
            this.First = First;
            this.Middle = Middle;
            this.Last = Last;
            this.Town = Town;
            this.Accounts = Accounts;


        }


    }

    
}
