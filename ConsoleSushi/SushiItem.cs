using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSushi
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
        public void ChangePrice(double newPrice)
        {
            Price = newPrice;
        }

       public override int GetHashCode()
       {
           return ToString().GetHashCode();
       }

       public override string ToString()
        {
            return $"Name: {SushiName}, Price: {Price}";
        }
 
        public override bool Equals(object item)
        {
            SushiItem sushi =  item as SushiItem;
            if (sushi == null)
            {
                return false;
            }
            return SushiName.Equals(sushi.SushiName)&&Price.Equals(sushi.Price);
        }
    }
}
