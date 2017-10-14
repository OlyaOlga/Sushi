using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSushi
{
    class Program
    {
        static void Main(string[] args)
        {
           CashRegister register = new CashRegister();
           Console.WriteLine(register.FoodItemList.ToString());
           Console.ReadKey();
        }
    }
}
