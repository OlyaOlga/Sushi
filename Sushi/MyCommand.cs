using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ConsoleSushi;

namespace Sushi
{
    class MenuCommand:
        ICommand
    {
        private Action _currentAction;
        private CashRegisterView _cashRegisterView;

        public MenuCommand(CashRegisterView cashRegisterView, Action currentAction)
        {
            _cashRegisterView = cashRegisterView;
            _currentAction = currentAction;
        }
        public bool CanExecute(object parameter)
        {
            return (_cashRegisterView.orderSushi.listView.SelectedIndex  != -1);
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _currentAction();
                int val = _cashRegisterView.orderSushi.listView.SelectedIndex;
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
    }
}
