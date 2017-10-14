using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSushi
{
    public class CurrentOrder<T>:
        IOrder<T> where T: IItem
    {
        public double TotalSum { get; private set; } = 0;
        public Dictionary<T, uint> Order { get; }
        public CurrentOrder()
        {
            TotalSum = 0;
            Order = new Dictionary<T, uint>();
        }

        public void OrderSomething(T item, uint quantity)
        {
            Order.Add(item, quantity);
            TotalSum += item.Price*quantity;
        }

        public void CancelOrder(T item)
        {
            if (Order.ContainsKey(item))
            {
                TotalSum -= item.Price*Order[item];
                Order.Remove(item);
            }
        }

        public void ChangeOrder(T item, uint quantity)
        {
            CancelOrder(item);
            OrderSomething(item, quantity);
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var item in Order)
            {
                result += $"{item.Key} quantity: {item.Value}/n";
            }
            return result;
        }
    }
}