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
            MenuChangeItemPriceCommand = new MenuCommand(this, ChangeMenuItemPrice);
        }

        public ICommand MenuItemDeleteCommand
        {
            get { return new MenuCommand(this, RemoveMenuItem); }
        }

        public ICommand MenuChangeItemPriceCommand { get; }

        public ICommand MoveEnteredPriceCommand
        {
            get { return new MenuCommand(this, MoveEnteredPrice); }
        }
        public void RemoveMenuItem()
        {
            cashRegister.Menu.RemoveItem(orderSushi.listView.SelectedItem as SushiItem);
        }

        public void ChangeMenuItemPrice()
        {
            //orderSushi.EnteredValueStackPannel.Visibility = System.Windows.Visibility.Visible;
            (orderSushi.listView.SelectedItem as SushiItem)?.ChangePrice(200);
        }

        public void MoveEnteredPrice()
        {
            uint newPrice;
            if (uint.TryParse(orderSushi.EnteredValueTextBox.Text, out newPrice))
            {
                (orderSushi.listView.SelectedItem as SushiItem).ChangePrice(newPrice);
            }
        }
       

    }
}
