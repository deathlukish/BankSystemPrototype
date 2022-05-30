using BankClientOperation;
using BankClientOperation.ClientType;
using BankSystemPrototype.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace BankSystemPrototype.ViewModels
{
    internal class MainWindowViewModel  : ViewModel
    {
        Repository _Repository = new Repository();
        private ObservableCollection<BaseClient> _Clients = new();
        private ObservableCollection<BaseAccount> _AccountsFrom = new ();
        private ObservableCollection<BaseAccount> _AccountsTo = new();
        private BaseAccount _SelectedAccountFrom;
        private BaseAccount _SelectedAccountTo;
        private BaseClient _SelectedClientFrom;
        private BaseClient _SelectedClientTo;
        private ClientTypeEnum _ClientTypeEnum;
        private float _ReplenishSum;
        public ICommand TestCommand { get; }
        //public ICommand AddAccount { get; }
        //public ICommand ReplenishCommand { get; }
        //public ICommand MoneyTransfer { get; }
        public ClientTypeEnum ClientTypeEnum
        {
            set
            {
                _ClientTypeEnum = value;

            }
        }
        public ObservableCollection<BaseClient> Clients
        {
           get => _Clients;
           set => Set(ref _Clients, value);
        
        }
        public ObservableCollection<BaseAccount> AccountsFrom
        {
            get => _AccountsFrom;
            set => Set(ref _AccountsFrom, value);
        
        }
        public ObservableCollection<BaseAccount> AccountsTo
        {
            get => _AccountsTo;
            set => Set(ref _AccountsTo, value);

        }
        public float ReplenishSum
        {
            get => _ReplenishSum;
            set => Set(ref _ReplenishSum, value);
        
        }
        public BaseAccount SelectedAccountFrom
        {

            get => _SelectedAccountFrom;
            set => Set(ref _SelectedAccountFrom, value);
        }
        public BaseAccount SelectedAccountTo
        {

            get => _SelectedAccountTo;
            set => Set(ref _SelectedAccountTo, value);
        }
        private void OnTestCommandCanEx(object p)
        {
            //var a = new EntityClient("Lukin", "Dmitii", "Genn", "Likino");
            //_Clients.Add(a);
            //_JsonBase.AddClient(a);
            AddClient addClient = new AddClient();
            addClient.DataContext = _Clients;
            addClient.Show();
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

        public BaseClient SelectedClientTo
        {
           
            get => _SelectedClientTo;
            set
            {
                Set(ref _SelectedClientTo, value);
                AccountsTo = _Repository.GetAccountsFromClient(SelectedClientTo.IdClient);
            }
            
        }

        private bool CanTestCommand(object p) => true;
        private bool CanAddAccount(object p) => _SelectedClientFrom !=null;
        private bool CanReplenishCommand(object p)
        {
            if (SelectedAccountFrom != null && ReplenishSum > 0)
            {
                return true;
            }
            else return false;

        }
        private bool CanMoneyTransfer(object p)
        {
            if (SelectedAccountFrom == SelectedAccountTo) return false;
            if (SelectedAccountFrom  == null ) return false;
            if (SelectedAccountTo == null) return false;
            else return true;

        }
        //private void OnMoneyTransfer(object p)
        //{
        //    MessageBox.Show(typeof(BaseAccount).Name);
       
        //}
        //private void OnReplenish(object p)
        //{

        //    _Repository.Replish(SelectedAccountFrom.NumAccount, ReplenishSum);
        //   // Accounts = _Repository.GetAccountsFromClient(SelectedClientFrom.IdClient);

        //}
        private void OnAddAccount(object p)
        {
            //var a = new NoDeposite(SelectedClientFrom.IdClient);
            ////_JsonBase.AddAccount(a);
            //if (_SelectedClientFrom.Accounts == null)
            //{
            //    _SelectedClientFrom.Accounts = new ObservableCollection<BaseAccount>();
            //}
            //_SelectedClientFrom.Accounts.Add(a);
            //_JsonBase.SaveBase(_Clients);
            _Repository.OpenAccount(SelectedClientFrom.IdClient);
        }

       // public 

        //private void GetClientOnDep(ClientTypeEnum clientTypeEnum)
        //{
        //    ClientOnDep 


        //}

        public MainWindowViewModel() 
        {

           // Clients = _Repository.GetClient();
            TestCommand = new RelayCommand(OnTestCommandCanEx, CanTestCommand);
           // AddAccount = new RelayCommand(OnAddAccount, CanAddAccount);
            //ReplenishCommand = new RelayCommand(OnReplenish, CanReplenishCommand);
            //MoneyTransfer = new RelayCommand(OnMoneyTransfer, CanMoneyTransfer);
            //var b = new EntityClient("Иван", "Иванович", "Иванов", "Москва");
            //var b = new Deposite(_Clients.Clients[0].IdClient);
            //_Clients.Accounts.Add(b);
            //_JsonBase.SaveBase(_Clients);
            //_JsonBase.AddClient(b);
        }
       
    }
}
