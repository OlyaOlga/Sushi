using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSushi
{
   public class SushiItem:
        IItem
    {
        public string Name { get;  private set; }      
        public double Price { get; private set; }

       public SushiItem()
       {
           
       }
        public SushiItem(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public void ChangePrice(double newPrice)
        {
            Price = newPrice;
        }

       public void ChangeName(string name)
       {
           Name = name;
       }

       public override int GetHashCode()
       {
           return ToString().GetHashCode();
       }

       public override string ToString()
        {
            return $"Sushi name: {Name}, Price: {Price}";
        }
 
       public override bool Equals(object item)
        {
            SushiItem sushi =  item as SushiItem;
            if (sushi == null)
            {
                return false;
            }
            return Name.Equals(sushi.Name)&&Price.Equals(sushi.Price);
        }
    }
}
