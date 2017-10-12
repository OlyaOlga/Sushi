using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi
{
   public class SushiItem:
        IChangeItem
    {
        public string SushiName { get;  private set; }      
        public double Price { get; private set; }

        public SushiItem(string sushiName, double price)
        {
            SushiName = sushiName;
            Price = price;
        }

        public override string ToString()
        {
            return $"Name: {SushiName}, Price: {Price}";
        }

        public void ChangePrice(double newPrice)
        {
            Price = newPrice;
        }
    }
}
