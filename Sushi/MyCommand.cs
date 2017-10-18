using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using ConsoleSushi;

namespace Sushi
{
    class MenuCommand:
        ICommand
    {
        private Action<int> _currentAction;
        private CashRegisterView _cashRegisterView;

        public MenuCommand(CashRegisterView cashRegisterView, Action<int> currentAction)
        {
            _cashRegisterView = cashRegisterView;
            _currentAction = currentAction;
        }
        public bool CanExecute(object parameter)
        {
            if (parameter == null)
            {
                return false;
            }
            int index = (int)parameter; 
            return (index  != -1);
        }

        public void Execute(object parameter)
        {
            if (parameter != null)
            {
                Console.WriteLine("Parametr is not null");
                Console.WriteLine("Parametr equls to " + parameter);
                _currentAction((int) parameter);
            }
            else
            {
                Console.WriteLine("Paramtr is null");
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
