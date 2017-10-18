using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSushi
{
    public class CurrentOrder<T>:
        IOrder<T> where T: IItem
    {
        private int findElementIndex(T element)
        {
            int resIndex = -1;
            for (int i = 0; i < Order.Count; ++i)
            {
                if (Order[i].Value.Equals(element))
                {
                    resIndex = i;
                    break;
                }
            }
            return resIndex;
        }
        public double TotalSum { get; private set; } = 0;
        public ObservableCollection<OrderEntity<T>> Order { get; }
        public CurrentOrder()
        {
            TotalSum = 0;
            Order = new ObservableCollection<OrderEntity<T>>();
        }

        public void OrderSomething(T item, uint quantity)
        {
            int elementIndex = findElementIndex(item);
            if (elementIndex == -1)
            {
                OrderEntity<T> toAdd = new OrderEntity<T>(item, quantity);
                Order.Add(toAdd);
                TotalSum += item.Price*quantity;
            }
            else
            {
                ChangeOrder(Order[elementIndex], quantity);
            }
        }

        public void CancelOrder(OrderEntity<T> item)
        {
            int foundIndex = findElementIndex(item.Value);
            if (foundIndex!=-1)
            {
                TotalSum -= item.Value.Price*Order[foundIndex].Quantity;
                Order.Remove(item);
            }
        }

        public void ChangeOrder(OrderEntity<T> item, uint newQuantity)
        {
            CancelOrder(item);
            OrderSomething(item.Value, newQuantity);
        }

        public override string ToString()
        {
            string result = string.Empty;
            foreach (var item in Order)
            {
                result += $"{item}/n";
            }
            return result;
        }
    }
}