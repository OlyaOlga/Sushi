using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSushi
{
    public class Order
    {
        public double TotalSum { get; private set; } = 0;
        public Dictionary<SushiItem, uint> CurrentOrder { get; }
        public Order()
        {
            TotalSum = 0;
            CurrentOrder = new Dictionary<SushiItem, uint>();
        }

        public void AddOrderItem(SushiItem item, uint quantity)
        {
            if (CurrentOrder.ContainsKey(item))
            {
                CurrentOrder[item] += quantity;
            }
            else
            {
                CurrentOrder.Add(item, quantity);
            }
            TotalSum += item.Price*quantity;
        }
    }
}
