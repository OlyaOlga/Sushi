using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSushi
{
    public interface IItem
    {
        string Name { get;}
        double Price { get;}
        void ChangePrice(double newPrice);
        void ChangeName(string name);
    }
}
