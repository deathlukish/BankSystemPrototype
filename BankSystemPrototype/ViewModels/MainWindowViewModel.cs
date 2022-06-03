using BankSystemPrototype;
using BankSystemPrototype.Commands;
using BankSystemPrototype.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace BankClientOperation
{
    internal class MainWindowViewModel<T> : ViewModel
        where T : BaseClient, new()
    {
        Repository _Repository = new Repository("./DB.json");
        private ObservableCollection<T> _Clients = new();
        private ObservableCollection<BaseAccount> _AccountsFrom;
        private ObservableCollection<BaseAccount> _AccountsTo = new();
        private BaseAccount _SelectedAccountFrom;
        private BaseAccount _SelectedAccountTo;
        private T _SelectedClientFrom;
        private T _SelectedClientTo = new();
        private float _ReplenishSum;
        private T Client;
        private string _FirstName;
        public ICommand AddClientCommand { get; }
        public ICommand OpenDeposite { get; }
        public ICommand OpenNoDeposite { get; }
        public ICommand SaveChange { get; }
        public ICommand CloseAccount { get; }
        public ICommand DelClientCommand { get; }
        public ICommand ReplanishAccount { get; }
        private void OnAddClient(object p)
        {

            var _AddClient = new AddClient();
            _AddClient.Show();
        }
        private void OnOpenDeposite(object p)
        {

            _Repository.OpenAccount(new Deposite(SelectedClientFrom.IdClient));
            AccountsFrom = _Repository.GetAccounts(_SelectedClientFrom.IdClient);


        }
        private void OnOpenNoDeposite(object p)
        {
            _Repository.OpenAccount(new NoDeposite(SelectedClientFrom.IdClient));
            AccountsFrom = _Repository.GetAccounts(_SelectedClientFrom.IdClient);
        }
        private void OnSaveChange(object p)
        {
            _Repository.SaveBase();
        }

        private void OnCloseAccount(object p)
        {
            _Repository.CloseAccount(SelectedAccountFrom.NumAccount);
            AccountsFrom = _Repository.GetAccounts(SelectedClientFrom.IdClient);

        }
        private void OnDelClientCommand(object p)
        {
            _Clients[_Clients.IndexOf(SelectedClientFrom)].IsActive = false;
            _Repository.SaveBase();
        }
        private void OnReplanishAccount(object p)
        {

            _Repository.ReplanishAccount(SelectedAccountFrom.NumAccount, ReplenishSum);
            AccountsFrom = _Repository.GetAccounts(SelectedClientFrom.IdClient);

        }
        private bool CanAddClient(object p) => true;
        private bool CanOpenDeposite(object p)
        {

            if (SelectedClientFrom != null)
            {
                if (AccountsFrom.Count(e => e is Deposite) == 0) return true;
            }
            return false;


        }
        private bool CanOpenNoDeposite(object p)
        {
            if (SelectedClientFrom != null)
            {
                if (AccountsFrom.Count(e => e is NoDeposite) == 0) return true;
            }
            return false;
        }
        private bool CanSaveChange(object p)
        {
            if (SelectedClientFrom != null)
            {
                if (SelectedClientFrom.IsCanChange) return true;
            }
            return false;
        }
        private bool CanDelClientCommand(object p) => SelectedClientFrom != null;
        private bool CanReplanishAccount(object p)
        {
            if (ReplenishSum > 0 && SelectedAccountFrom != null) return true;
            else return false;
        }
        public MainWindowViewModel()
        {
            GetClients();
            AddClientCommand = new RelayCommand(OnAddClient, CanAddClient);
            OpenDeposite = new RelayCommand(OnOpenDeposite, CanOpenDeposite);
            OpenNoDeposite = new RelayCommand(OnOpenNoDeposite, CanOpenNoDeposite);
            SaveChange = new RelayCommand(OnSaveChange, CanSaveChange);
            CloseAccount = new RelayCommand(OnCloseAccount, CanCloseAccount);
            DelClientCommand = new RelayCommand(OnDelClientCommand, CanDelClientCommand);
            ReplanishAccount = new RelayCommand(OnReplanishAccount, CanReplanishAccount);
        }

        private bool CanCloseAccount(object p)
        {
            if (_SelectedAccountFrom != null && SelectedAccountFrom.Balance==0) return true;

            else return false;
        
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
            get => _Clients;
            set { 

                //_Clients = value;
                Set(ref _Clients, value);
          
            }

        }
        public T SelectedClientFrom
        {
            get => _SelectedClientFrom;
            set
            {
                Set(ref _SelectedClientFrom, value);
                AccountsFrom = _Repository.GetAccounts(_SelectedClientFrom.IdClient);
             
            }


        }
        public string FirsName 
        {
            get => _FirstName;
            set => Set(ref _FirstName, value);
        }

        
        public void GetClients()
        {
            foreach (var a in _Repository.GetClient().Where(e => e is T && e.IsActive))
            {
                _Clients.Add((T)a);
            }
        }

        public float ReplenishSum
        { 
            get => _ReplenishSum;
            set => Set(ref _ReplenishSum, value);

        }

    }
}
