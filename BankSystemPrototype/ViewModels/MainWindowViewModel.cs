using BankClientOperation.AccountType;
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
        where T : BaseClient, IBankAccount<T>
    {
        Repository _Repository = new Repository("./DB.json");
        private ObservableCollection<T> _Clients = new();
        private BaseAccount<T> _SelectedAccountFrom;
        private BaseAccount<T> _SelectedAccountTo;
        private T _SelectedClientFrom;
        private BaseClient _SelectedClientTo;
        private float _ReplenishSum;
        private float _TransSum;
        #region Свойтва
        public ICommand AddClientCommand { get; }
        public ICommand OpenDeposite { get; }
        public ICommand OpenNoDeposite { get; }
        public ICommand SaveChange { get; }
        public ICommand CloseAccount { get; }
        public ICommand DelClientCommand { get; }
        public ICommand ReplanishAccount { get; }
        public ICommand MoneyTransfer { get; }
        public BaseAccount<T> SelectedAccountFrom
        {

            get => _SelectedAccountFrom;
            set => Set(ref _SelectedAccountFrom, value);
        }
        public ObservableCollection<T> Clients
        {
            get => _Clients;
            set => Set(ref _Clients, value);
        }
        public T SelectedClientFrom
        {
            get => _SelectedClientFrom;
            set
            {
                Set(ref _SelectedClientFrom, value);
            }

        }
        public BaseClient SelectedClientTo
        {
            get => _SelectedClientTo;
            set => Set(ref _SelectedClientTo, value);
        }
        public BaseAccount<T> SelectedAccountTo
        {
            get => _SelectedAccountTo;
            set => Set(ref _SelectedAccountTo, value);
        }
        public float ReplenishSum
        {
            get => _ReplenishSum;
            set => Set(ref _ReplenishSum, value);

        }
        public float TransSum
        {
            get => _TransSum;
            set => Set(ref _TransSum, value);

        }
        #endregion
        /// <summary>
        /// Метод вызова окна добавления клиента
        /// </summary>
        /// <param name="p"></param>
        private void OnAddClient(object p)
        {

            AddClient _AddClient = new();
            _AddClient.ShowDialog();
            if (_AddClient.DialogResult ?? false)
            {
                _Repository.AddClient(
                   (_AddClient.DataContext as AddClientViewModel).ClientType,
                   (_AddClient.DataContext as AddClientViewModel).FirsName,
                   (_AddClient.DataContext as AddClientViewModel).MiddleName,
                   (_AddClient.DataContext as AddClientViewModel).LastName,
                   (_AddClient.DataContext as AddClientViewModel).Town);

            }

        }
        /// <summary>
        /// Метод открытия Депозитного счета
        /// </summary>
        /// <param name="p"></param>
        private void OnOpenDeposite(object p)
        {
            SelectedClientFrom.AddAccount(new Deposite<T>(_Repository.GenId()));
            _Repository.SaveBase();

        }
        /// <summary>
        /// Метод открытия недепозитного счета
        /// </summary>
        /// <param name="p"></param>
        private void OnOpenNoDeposite(object p)
        {
            SelectedClientFrom.AddAccount(new NoDeposite<T>(_Repository.GenId()));
            _Repository.SaveBase();
        }
        /// <summary>
        /// Метод сохранения изменения клиента
        /// </summary>
        /// <param name="p"></param>
        private void OnSaveChange(object p)
        {
            _Repository.SaveBase();
        }
        /// <summary>
        /// Закрытие счета
        /// </summary>
        /// <param name="p"></param>
        private void OnCloseAccount(object p)
        {

            SelectedClientFrom.Accounts.Remove((BaseAccount<T>)p);
           
        }
        /// <summary>
        /// Удаление клиента
        /// </summary>
        /// <param name="p"></param>
        private void OnDelClientCommand(object p)
        {
            _Clients[_Clients.IndexOf(SelectedClientFrom)].IsActive = false;
            _Repository.SaveBase();
        }
        /// <summary>
        /// Пополнение счета
        /// </summary>
        /// <param name="p"></param>
        private void OnReplanishAccount(object p)
        {

            if (p as IAccountCovariant<T, BaseAccount<T>> != null)
            {
                (p as IAccountCovariant<T, BaseAccount<T>>).PutMoney(ReplenishSum);
                ReplenishSum = 0.0F;
            }
            _Repository.SaveBase();

        }
        /// <summary>
        /// Перевод между счетами
        /// </summary>
        /// <param name="p"></param>
        private void OnMoneyTransfer(object p)
        {
            (SelectedAccountFrom as IAccountContrVariant<T, BaseAccount<T>>).TransAccountToAccount((BaseAccount<T>)SelectedAccountTo, TransSum);
            TransSum = 0.0F;
            _Repository.SaveBase();
        }
        /// <summary>
        /// Получить клиентов из репозитория и передаем делегат для события
        /// </summary>
        private void GetClients()
        {

            foreach (var a in _Repository.GetClient().Where(e => e is T && e.IsActive))
            {
                a.MessageAction = ShowMessage;
                _Clients.Add((T)a);

            }

        }
        private bool CanAddClient(object p) => true;
        private bool CanOpenDeposite(object p)
        {

            if (SelectedClientFrom != null)
            {
                if (SelectedClientFrom.Accounts.Count(e => e is Deposite<T>) == 0) return true;
            }
            return false;


        }
        private bool CanOpenNoDeposite(object p)
        {
            if (SelectedClientFrom != null)
            {
                if (SelectedClientFrom.Accounts.Count(e => e is NoDeposite<T>) == 0) return true;
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
        private bool CanMoneyTransfer(object p)
        {
            if (SelectedAccountFrom != null && SelectedAccountTo != null && TransSum != 0) return true;
            else return false;
        
        }
        private bool CanCloseAccount(object p)
        {
            if (_SelectedAccountFrom != null && SelectedAccountFrom.Balance == 0) return true;

            else return false;

        }
        public void ShowMessage(string textToShow)
        {
            MessageBox.Show(textToShow);
        }
        /// <summary>
        /// Конструктор
        /// </summary>
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
            MoneyTransfer = new RelayCommand(OnMoneyTransfer, CanMoneyTransfer);


        }
          

    }
}
