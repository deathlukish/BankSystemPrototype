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

    }
}
