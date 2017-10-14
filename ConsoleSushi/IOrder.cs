using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSushi
{
    public interface IOrder<T>
    {
        void OrderSomething(T value, uint quantity);
        void CancelOrder(T value);
        void ChangeOrder(T value, uint quantity);
    }
}
