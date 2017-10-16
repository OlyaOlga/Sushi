using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        public ICommand MenuItemDeleteCommand
        {
            get { return new MenuCommand(this, RemoveMenuItem); }
        }

        public ICommand MenuChangeItemPriceCommand
        {
            get
            {
                return new MenuCommand(this, ChangeMenuItemPrice);
            }
        }

        public void RemoveMenuItem()
        {
            cashRegister.Menu.RemoveItem(orderSushi.listView.SelectedItem as SushiItem);
        }

        public void ChangeMenuItemPrice()
        {
            (orderSushi.listView.SelectedItem as SushiItem).ChangePrice(200);
        }
    }
}
