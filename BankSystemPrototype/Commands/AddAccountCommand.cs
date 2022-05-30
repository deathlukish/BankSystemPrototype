using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BankSystemPrototype.Commands
{
    class AddAccountCommand : BaseCommand
    {

        private AddClient _Window;
        public override bool CanExecute(object parameter) => _Window == null;

        public override void Execute(object parameter)
        {
            var Window = new AddClient 
            { 
            
            Owner = Application.Current.MainWindow
            
            };
            _Window = Window;
            Window.Closed += OnWinClosed;
            Window.ShowDialog();
        }
        private void OnWinClosed(object Sender, EventArgs e)
        {

        
        }
    }
}
