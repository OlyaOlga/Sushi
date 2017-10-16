using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ConsoleSushi;
using Sushi.Properties;

namespace Sushi
{
    /// <summary>
    /// Interaction logic for OrderSushi.xaml
    /// </summary>
    public partial class OrderSushi : Window
    {
        public OrderSushi()
        {
            InitializeComponent();
        }

        public void InitializeChosenElements()
        {
            try
            {
                ((CashRegisterView) DataContext).cashRegister.CurrentSushiOrder.Order.Add(
                    new SushiItem("sushiTasty", 50),
                    100);
            }
            catch(Exception)
            { }
            Resources["CurrentOrder"] = ((CashRegisterView)DataContext).cashRegister.CurrentSushiOrder.Order;
        }

        private void ChangePriceButton_Click(object sender, RoutedEventArgs e)
        {
            if ((listView.SelectedItem as SushiItem) !=null)
            {
                (listView.SelectedItem as SushiItem).ChangePrice(200);
            }
        }

        private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {
            if ((listView.SelectedItem as SushiItem) != null)
            {
                ((CashRegisterView) DataContext).cashRegister.Menu.RemoveItem(listView.SelectedItem as SushiItem);
            }
        }
    }
}
