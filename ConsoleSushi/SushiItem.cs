using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ConsoleSushi.Annotations;

namespace ConsoleSushi
{
   public class SushiItem:
        IItem,
        INotifyPropertyChanged
   {
       private string _name;
       private double _price;

       public string Name
       {
           get
           {
               return _name;
           }
           private set
           {
               _name = value;
               OnPropertyChanged("Name");
           }
       }

       public double Price
       {
           get { return _price; }
           private set
           {
               _price = value;
               OnPropertyChanged("Price");
           }
       }

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

       public event PropertyChangedEventHandler PropertyChanged;

       [NotifyPropertyChangedInvocator]
       protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
       {
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
       }
   }
}
