using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSushi
{
    public class AvaliableSushi:
        IChangeDataContainers<SushiItem>
    {
        public List<SushiItem> AllSushiItems { get; }

        public AvaliableSushi()
        {
            AllSushiItems = new List<SushiItem>();
        }

        public void AddItem(SushiItem item)
        {
            AllSushiItems.Add(item);
        }

        public void RemoveItem(SushiItem item)
        {
            AllSushiItems.Remove(item);
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var item in AllSushiItems)
            {
                result += item.ToString();
                result += '\n';
            }
            return result;
        }
    }
}
