
using BankClientOperation.AccountType;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
       /// private List<BaseAccount> _Accounts;
        public Guid IdClient { get; set; }
        public string First { get => _First; set => Set(ref _First, value); }
        public string Middle { get => _Middle; set => Set(ref _Middle, value); }
        public string Last { get => _Last; set => Set(ref _Last, value); }
        public  string Town { get => _Town; set => Set(ref _Town, value); }
        public bool IsActive { get => _IsActive; set => Set(ref _IsActive, value); }
        public virtual bool IsCanChange { get; set; } = true;
        //private ObservableCollection<BaseAccount<BaseClient>> _Accounts = new ObservableCollection<BaseAccount<BaseClient>>();
        //public ObservableCollection<BaseAccount<BaseClient>> Accounts { get => _Accounts; set => _Accounts = value; }

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

        public void AddAccount(BaseAccount<BaseClient> account)
        {
            throw new NotImplementedException();
        }

        public void RemoveAccount(BaseAccount<BaseClient> account)
        {
            throw new NotImplementedException();
        }

        public BaseClient()
        {
        
        
        }
        public BaseClient(Guid IdClient, string First, string Middle, string Last, string Town, bool IsActive)
        {
            this.IdClient = IdClient;
            this.IsActive = IsActive;
            this.First = First;
            this.Middle = Middle;
            this.Last = Last;
            this.Town = Town;
          //  this.Accounts = Accounts;


        }


    }

    
}
