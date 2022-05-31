using BankClientOperation;
using BankClientOperation.ClientType;
using BankSystemPrototype.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankSystemPrototype.ViewModels
{
    class AddClientViewModel : ViewModel
    {
        private Repository repository = new Repository();
        private string _FirstName;
        private string _MiddleName;
        private string _LastName;
        private string _Town;
        private ClientTypeEnum _ClientType;
        public string FirsName
        {
            get => _FirstName;
            set => Set(ref _FirstName, value);
            
        }
        public string MiddleName
        {
            get => _MiddleName;
            set => Set(ref _MiddleName, value);

        }
        public string LastName
        {
            get => _LastName;
            set => Set(ref _LastName, value);

        }
        public string Town
        {
            get => _Town;
            set => Set(ref _Town, value);

        }
        public ClientTypeEnum ClientType
        {
            get => _ClientType;
            set => Set(ref _ClientType, value);

        }
        public ICommand AddClient { get; }
        private bool CanAddClient(object p)
        {
            if (FirsName != null
                    && FirsName != null
                    && MiddleName != null
                    && LastName != null
                    && Town != null) return true;
            return false;
        }
        private void OnAddClient(object p)
        {
  
            switch (ClientType)
            {
                case ClientTypeEnum.Entity:
                    MessageBox.Show("Entity");
                    repository.AddClient(new EntityClient(Guid.NewGuid(), FirsName, MiddleName, LastName, Town, true));                    
                    break;
                case ClientTypeEnum.Regular:
                    MessageBox.Show("Regular");
                    repository.AddClient(new RegularClient(Guid.NewGuid(), FirsName, MiddleName, LastName, Town, true));
                    break;
                case ClientTypeEnum.VIP:
                    repository.AddClient (new VipClient(Guid.NewGuid(), FirsName, MiddleName, LastName, Town, true));
                    MessageBox.Show("VIP");
                    break;

            }
            
        }
        public AddClientViewModel()
        {
            AddClient = new RelayCommand(OnAddClient, CanAddClient);
        }
    }
}
