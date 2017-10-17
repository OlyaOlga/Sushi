using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSushi
{
    public class PossibleVariants<T> :
        IFileActions,
        IChangeDataContainers<T> where T :IItem, new()
    {
        public ObservableCollection<T> AllPossibleItems { get; set; }

        public PossibleVariants()
        {
            AllPossibleItems = new ObservableCollection<T>();
        }

        public void AddItem(T item)
        {
            AllPossibleItems.Add(item);
        }

        public void RemoveItem(T item)
        {
            AllPossibleItems.Remove(item);
        }
        
        public override string ToString()
        {
            string result = string.Empty;
            foreach (var item in AllPossibleItems)
            {
                result += item.ToString();
                result += '\n';
            }
            return result;
        }

        public void ReadData(string source)
        {
            string [] data = File.ReadAllLines(source);
            foreach (var item in data)
            {
                T value = new T();
                string[] currentElement = item.Split(' ');
                value.ChangeName(currentElement[0]);
                double price;
                double.TryParse(currentElement[1], out price); 
                value.ChangePrice(price);
                AllPossibleItems.Add(value);
            }
        }

        public void WriteData(string destination)
        {
            throw new NotImplementedException();
        }
    }
}
