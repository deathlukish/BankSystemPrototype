using BankSystemPrototype;
using BankSystemPrototype.Commands;
using BankSystemPrototype.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace BankClientOperation
{
    internal class AccountOperation<T> : ViewModel
        where T : BaseClient, new()
    {
        Repository _Repository = new Repository();
        private ObservableCollection<T> _Clients = new();
        private ObservableCollection<BaseAccount> _AccountsFrom = new();
        private ObservableCollection<BaseAccount> _AccountsTo = new();
        private BaseAccount _SelectedAccountFrom;
        private BaseAccount _SelectedAccountTo;
        private T _SelectedClientFrom = new(); 
        private T _SelectedClientTo = new();
        private float _ReplenishSum;
        private T Client;
        private string _FirstName;
        public ICommand AddClientCommand { get; }
        public ICommand OpenDeposite { get; }
        private void OnAddClient(object p)
        {
            
            var _AddClient = new AddClient();
           _AddClient.Show();
        }
        private void OnOpenDeposite(object p)
        {
            
            SelectedClientFrom.Accounts.Add(new Deposite(SelectedClientFrom.IdClient));
            _Repository.SaveBase();
        }
        private bool CanAddClient(object p) => true;
        private bool CanOpenDeposite(object p)
        {
            
            if (SelectedClientFrom.Accounts == null) SelectedClientFrom.Accounts = new List<BaseAccount>();
            if ((SelectedClientFrom.Accounts.FindAll(e => e is Deposite).Count == 0)) return true;
            else return false;
        
        
        }
        public AccountOperation()
        {
            GetClients();
            AddClientCommand = new RelayCommand(OnAddClient, CanAddClient);
            OpenDeposite = new RelayCommand(OnOpenDeposite, CanOpenDeposite);
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

                _Clients = value;
                Set(ref _Clients, value);
          
            }

        }
        public T SelectedClientFrom
        {
            get => _SelectedClientFrom;
            set
            {
                Set(ref _SelectedClientFrom, value);
             
            }


        }
        public string FirsName 
        {
            get => _FirstName;
            set => Set(ref _FirstName, value);
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
        



    }
}
