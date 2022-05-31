using BankClientOperation.ClientType;
using BankSystemPrototype;
using BankSystemPrototype.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankClientOperation
{
    public class AccountOperation<T> : INotifyPropertyChanged
        where T : BaseClient
    {
        Repository _Repository = new Repository();
        private ObservableCollection<T> _Clients = new();
        private ObservableCollection<BaseAccount> _AccountsFrom = new();
        private ObservableCollection<BaseAccount> _AccountsTo = new();
        private BaseAccount _SelectedAccountFrom;
        private BaseAccount _SelectedAccountTo;
        private BaseClient _SelectedClientFrom;
        private BaseClient _SelectedClientTo;
        private float _ReplenishSum;
        private T Client;
        public ICommand AddClientCommand { get; }
        private void OnAddClient(object p)
        {
            var _AddClient = new AddClient();
            _AddClient.Show();
            //MessageBox.Show("sdasdadasdas");
        }
        private bool CanAddClient(object p) => true;
        public AccountOperation()
        {
            GetClients();
            AddClientCommand = new RelayCommand(OnAddClient, CanAddClient);
        }
        public BaseAccount SelectedAccountFrom
        {

            get => _SelectedAccountFrom;
            set => Set(ref _SelectedAccountFrom, value);
        }
        public ObservableCollection<BaseAccount> AccountsFrom
        {
            get => _AccountsFrom;
            set => Set(ref _AccountsFrom, value);

        }
        public ObservableCollection<T> Clients
        {
            get
            {
                
                return _Clients;
            }
            set { 

                _Clients = value;
                Set(ref _Clients, value);
          
            }

        }
        public BaseClient SelectedClientFrom
        {
            get => _SelectedClientFrom;
            set
            {
                Set(ref _SelectedClientFrom, value);
                AccountsFrom = _Repository.GetAccountsFromClient(SelectedClientFrom.IdClient);
            }


        }
        public void Replenish()
        {

            //Account.Balance += Sum;
            //Client.

        }
        public void OpenAccount()
        {
        
        }

        public void CloseAccount()
        { 
        
        }
        public void GetClients()
        {
            foreach (var a in _Repository.GetClient().FindAll(e => e is T))
            {
                _Clients.Add((T)a);
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
