using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
