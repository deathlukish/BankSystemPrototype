﻿using BankClientOperation.AccountType;
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
        public ICommand AddClientCommand { get; }
        public ICommand OpenDeposite { get; }
        public ICommand OpenNoDeposite { get; }
        public ICommand SaveChange { get; }
        public ICommand CloseAccount { get; }
        public ICommand DelClientCommand { get; }
        public ICommand ReplanishAccount { get; }
        public ICommand MoneyTransfer { get; }
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
        private void OnOpenDeposite(object p)
        {
            SelectedClientFrom.AddAccount(new Deposite<T>(SelectedClientFrom.IdClient, _Repository.GenId()));
            _Repository.SaveBase();

        }
        private void OnOpenNoDeposite(object p)
        {
            SelectedClientFrom.AddAccount(new NoDeposite<T>(SelectedClientFrom.IdClient, _Repository.GenId()));
            _Repository.SaveBase();
        }
        private void OnSaveChange(object p)
        {
            _Repository.SaveBase();
        }

        private void OnCloseAccount(object p)
        {
          //  _Repository.CloseAccount(SelectedAccountFrom.NumAccount);
           // AccountsFrom = _Repository.GetAccounts(SelectedClientFrom.IdClient);

        }
        private void OnDelClientCommand(object p)
        {
            _Clients[_Clients.IndexOf(SelectedClientFrom)].IsActive = false;
            _Repository.SaveBase();
        }
        private void OnReplanishAccount(object p)
        {                     
            PutMoneyToAccount(p as IAccountCovariant<T, BaseAccount<T>>);
        }
        private void OnMoneyTransfer(object p)
        {

            TransAccountToAccount(SelectedAccountFrom, SelectedAccountTo);

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
        private bool CanMoneyTransfer(object p) => true;
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

        private bool CanCloseAccount(object p)
        {
            if (_SelectedAccountFrom != null && SelectedAccountFrom.Balance==0) return true;

            else return false;
        
        }
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
        private void GetClients()
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

        private void PutMoneyToAccount(IAccountCovariant<T, BaseAccount<T>> account)
        {
            if (account != null)
            {
                account.PutMoney(ReplenishSum);
                ReplenishSum = 0.0F;
            }
            _Repository.SaveBase();
        }
        private void TransAccountToAccount(IAccountContrVariant<T, BaseAccount<T>> fromAccount, BaseAccount<T> toAccount)
        {

            fromAccount.TransAccountToAccount(toAccount, ReplenishSum);
            _Repository.SaveBase();
        }

    }
}
