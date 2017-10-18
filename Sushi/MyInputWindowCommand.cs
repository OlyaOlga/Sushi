using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sushi
{
    class MyInputWindowCommand:
        ICommand
    {
        private Action _currentAction;

        public MyInputWindowCommand(Action action)
        {
            _currentAction = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _currentAction();
        }

        public event EventHandler CanExecuteChanged;
    }
}
