using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSushi
{
    public interface IOrder<T> where T: IItem
    {
        void OrderSomething(T value, uint quantity);
        void CancelOrder(OrderEntity<T> value);
        void ChangeOrder(OrderEntity<T> item, uint newQuantity);
    }
}
