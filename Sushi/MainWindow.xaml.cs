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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsoleSushi;

namespace Sushi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public CashRegisterView currentView;
        public MainWindow()
        {
            InitializeComponent();
            currentView = new CashRegisterView();
            currentView.mainWindow = this;
            DataContext = currentView;
        }

        private void DoOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderSushi sushi = new OrderSushi();
            sushi.DataContext = this.DataContext;
            currentView.orderSushi = sushi;
            sushi.ShowDialog();
        }
    }
}
