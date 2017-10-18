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

        private void ListView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine( listView.SelectedIndex);
            foreach (var addedItem in e.AddedItems)
            {
                Console.WriteLine("\t"+addedItem);
            }
        }
    }
}
