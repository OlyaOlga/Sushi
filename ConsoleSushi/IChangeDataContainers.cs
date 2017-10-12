using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSushi
{
    interface IChangeDataContainers<T>
    {
        void AddItem(T item);
        void RemoveItem(T item);
    }
}
