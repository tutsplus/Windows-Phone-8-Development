using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App9.Commands
{
    public class PayCommand : ICommand {
        private Action _execute;
        private Func<bool> _canExecute; 

        public PayCommand( Action execute, Func<bool> canExecute ) {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute( object parameter ) {
            return _canExecute( );
        }

        public void Execute( object parameter ) {
            _execute( );
            CanExecuteChanged(this, new EventArgs());
        }

        public event EventHandler CanExecuteChanged;
    }
}
