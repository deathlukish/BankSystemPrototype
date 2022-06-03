
using BankClientOperation;
using BankClientOperation.ClientType;
using System;
using System.Windows;


namespace BankSystemPrototype
{
    /// <summary>
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
       // Repository repository = new Repository();
        public AddClient()
        {
            
            InitializeComponent();
            ClientType.ItemsSource = Enum.GetValues(typeof(ClientTypeEnum));

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
