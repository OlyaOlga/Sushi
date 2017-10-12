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
            SushiItem item = new SushiItem("123", 12.3);
            AvaliableSushi sushi = new AvaliableSushi();
            sushi.AddItem(item);
            SushiItem anotherItem = new SushiItem("124", 12.3);
            sushi.AddItem(item);
            sushi.AddItem(item);
            sushi.AddItem(anotherItem);
            Console.WriteLine(sushi);
            Console.ReadKey();
        }
    }
}
