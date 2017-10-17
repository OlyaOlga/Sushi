using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ConsoleSushi;

namespace Sushi
{
    public class CashRegisterView
    {
        public CashRegister cashRegister { get; set; }

        public MainWindow mainWindow { get; set; }

        public OrderSushi orderSushi { get; set; }

        public CashRegisterView()
        {
            cashRegister = new CashRegister();
            MenuChangeItemPriceCommand = new MenuCommand(this, new Action<int>(ChangeMenuItemPrice));
            MenuItemDeleteCommand = new MenuCommand(this, RemoveMenuItem);
            MovePriceCommand = new MenuCommand(this, MoveEnteredPrice);
            CancelEnteringPriceCommand = new MenuCommand(this, CancelEnteringPrice);
        }

        public ICommand MenuChangeItemPriceCommand { get; }

        public ICommand MenuItemDeleteCommand { get; }

        public ICommand MovePriceCommand { get; }

        public ICommand CancelEnteringPriceCommand { get;}

        public void RemoveMenuItem(int index)
        {
            cashRegister.Menu.RemoveItem(cashRegister.Menu.AllPossibleItems[index]);
        }

        public void ChangeMenuItemPrice(int index)
        {
            orderSushi.EnteredValueStackPannel.Visibility = Visibility.Visible;
        }

        public void MoveEnteredPrice(int index)
        {
            double newPrice;
            if (double.TryParse(orderSushi.EnteredValueTextBox.Text, out newPrice))
            {
                orderSushi.listView.SelectedIndex = -1;
                cashRegister.Menu.AllPossibleItems[index].ChangePrice(newPrice);
                orderSushi.EnteredValueStackPannel.Visibility = Visibility.Hidden;
            }
            orderSushi.EnteredValueTextBox.Text = string.Empty;
        }

        public void CancelEnteringPrice(int index)
        {
            orderSushi.listView.SelectedIndex = -1;
            orderSushi.EnteredValueTextBox.Text = string.Empty;
            orderSushi.EnteredValueStackPannel.Visibility = Visibility.Hidden;
        }
       

    }
}
