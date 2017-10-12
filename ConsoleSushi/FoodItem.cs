﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSushi
{
    public class FoodItem:
        IChangeItem
    {
        public string Name { get; private set; }
        public double Price { get; private set; }

        public FoodItem(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public void ChangePrice(double newPrice)
        {
            Price = newPrice;
        }

        public override bool Equals(object obj)
        {
            FoodItem food = obj as FoodItem;
            if (food == null)
            {
                return false;
            }
            return Name.Equals(food.Name) && Price.Equals(food.Price);
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}";
        }
    }
}