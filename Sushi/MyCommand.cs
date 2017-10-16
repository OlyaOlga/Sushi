using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ConsoleSushi;

namespace Sushi
{
    class MyDeleteCommand:
        ICommand
    {
        private CashRegisterView _cashRegisterView;

        public MyDeleteCommand(CashRegisterView cashRegisterView)
        {
            _cashRegisterView = cashRegisterView;
        }
        public bool CanExecute(object parameter)
        {
            return ((_cashRegisterView.orderSushi.listView.SelectedItem as SushiItem) != null);
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _cashRegisterView.cashRegister.Menu.RemoveItem(_cashRegisterView.orderSushi.listView.SelectedItem as SushiItem);
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
