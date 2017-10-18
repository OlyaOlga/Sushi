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

namespace Sushi
{
    /// <summary>
    /// Interaction logic for InputValueWindow.xaml
    /// </summary>
    public partial class InputValueWindow : Window
    {
        public InputValueWindow(object dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
            OkCommand = new MyInputWindowCommand(Ok);
            CancelCommand = new MyInputWindowCommand(Cancel);
            OkButton.DataContext = this;
            CancelButton.DataContext = this;
        }

        public ICommand OkCommand { get; }
        public ICommand CancelCommand { get; }

        public void Ok()
        {
            this.Close();
        }

        public void Cancel()
        {
            ((CashRegisterView) DataContext).Q = null;
            this.Close();
        }
    }
}
