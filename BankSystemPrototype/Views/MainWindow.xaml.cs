﻿using BankClientOperation;
using BankClientOperation.ClientType;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BankSystemPrototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {

            InitializeComponent();
            ClientType.ItemsSource = Enum.GetValues(typeof(ClientTypeEnum));

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ClientType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ClientType.SelectedItem)
            {
                
                case ClientTypeEnum.Entity:                    
                    this.DataContext = new AccountOperation<EntityClient>();
                    break;
                case ClientTypeEnum.Regular:
                    this.DataContext = new AccountOperation<RegularClient>();
                    break;
                case ClientTypeEnum.VIP:
                    this.DataContext = new AccountOperation<VipClient>();
                    break;

            }

        }
    }
}

