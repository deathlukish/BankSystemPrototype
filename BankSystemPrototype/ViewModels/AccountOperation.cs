using BankSystemPrototype;
using BankSystemPrototype.Commands;
using BankSystemPrototype.ViewModels;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace BankClientOperation
{
    internal class AccountOperation<T> : ViewModel
        where T : BaseClient
    {
        Repository _Repository = new Repository();
        private ObservableCollection<T> _Clients = new();
        private ObservableCollection<BaseAccount> _AccountsFrom = new();
        private ObservableCollection<BaseAccount> _AccountsTo = new();
        private BaseAccount _SelectedAccountFrom;
        private BaseAccount _SelectedAccountTo;
        private T _SelectedClientFrom;
        private T _SelectedClientTo;
        private float _ReplenishSum;
        private T Client;
        private string _FirstName;
        public ICommand AddClientCommand { get; }
        public ICommand SaveChange { get; }
        private void OnAddClient(object p)
        {
            
            var _AddClient = new AddClient();
           _AddClient.Show();
        }
        private bool CanAddClient(object p) => true;
        private void OnSaveChange(object p)
        {

            _Repository.SaveBase();
        }
        private bool CanSaveChange(object p) => true;
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
        public T SelectedClientFrom
        {
            get => _SelectedClientFrom;
            set
            {
                Set(ref _SelectedClientFrom, value);
                AccountsFrom = _Repository.GetAccountsFromClient(SelectedClientFrom.IdClient);
            }


        }
        public string FirsName 
        {
            get => _FirstName;
            set => Set(ref _FirstName, value);
        }

        public void Replenish()
        {

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
