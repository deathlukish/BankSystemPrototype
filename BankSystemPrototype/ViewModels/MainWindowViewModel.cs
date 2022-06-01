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
    internal class MainWindowViewModel<T> : ViewModel
        where T : BaseClient, new()
    {
        Repository _Repository = new Repository();
        private ObservableCollection<T> _Clients = new();
        private ObservableCollection<BaseAccount> _AccountsFrom; 
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
        public ICommand OpenNoDeposite { get; }
        public ICommand SaveChange { get; set; }
        private void OnAddClient(object p)
        {
            
            var _AddClient = new AddClient();
           _AddClient.Show();
        }
        private void OnOpenDeposite(object p)
        {
                       
            OpenAccount(new Deposite(SelectedClientFrom.IdClient));

        }
        private void OnOpenNoDeposite(object p)
        {
            OpenAccount(new NoDeposite(SelectedClientFrom.IdClient));
        }
        private void OnSaveChange(object p)
        {
            _Repository.SaveBase();
        }
        private void OpenAccount<A>(A ee) where A:BaseAccount
        {
            if (_SelectedClientFrom.Accounts == null) _SelectedClientFrom.Accounts = new();
            SelectedClientFrom.Accounts.Add(ee);
            _Repository.SaveBase();

        }

        private bool CanAddClient(object p) => true;
        private bool CanOpenDeposite(object p)
        {


            if (_SelectedClientFrom.Accounts == null) return true;
            if (_SelectedClientFrom.Accounts?.FindAll(e => e is Deposite).Count == 0) return true;
            return false;


        }
        private bool CanOpenNoDeposite(object p)
        {

            if (_SelectedClientFrom.Accounts == null) return true;
            if (_SelectedClientFrom.Accounts?.FindAll(e => e is NoDeposite).Count == 0) return true;
            return false;
        }
        private bool CanSaveChange(object p)
        {
            if (_SelectedClientFrom is VipClient) return false;
            else return true;

        
        }
        public MainWindowViewModel()
        {
            GetClients();
            AddClientCommand = new RelayCommand(OnAddClient, CanAddClient);
            OpenDeposite = new RelayCommand(OnOpenDeposite, CanOpenDeposite);
            OpenNoDeposite = new RelayCommand(OnOpenNoDeposite, CanOpenNoDeposite);
            SaveChange = new RelayCommand(OnSaveChange, CanSaveChange);
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
