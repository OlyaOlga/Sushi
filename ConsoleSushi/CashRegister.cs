using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSushi
{
    public class CashRegister:
        IFileActions
    {
        private string foodItemsFile = "data.txt";
        private string sushiItemsFile = "sushiItems.txt";
        private double TotalSum = 0;
        CurrentOrder<SushiItem> CurrentSushiOrder;
        CurrentOrder<FoodItem> CurrentFoodItemsOrder;
        CurrentOrder<IItem> ItemsFromFile;
        public PossibleVariants<FoodItem> FoodItemList { get; set; }
        public PossibleVariants<SushiItem> Menu { get; private set; }
        public CashRegister()
        {
            CurrentSushiOrder = new CurrentOrder<SushiItem>();
            CurrentFoodItemsOrder = new CurrentOrder<FoodItem>();
            ItemsFromFile = new CurrentOrder<IItem>();
            FoodItemList = new PossibleVariants<FoodItem>();
            Menu = new PossibleVariants<SushiItem>();
            FoodItemList.ReadData(foodItemsFile);
            //Menu.ReadData(sushiItemsFile);
        }
        public void ReadData(string source)
        {
            throw new NotImplementedException();
        }


        public void WriteData(string destination)
        {
            throw new NotImplementedException();
        }
    }
}
