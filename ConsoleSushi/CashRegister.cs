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
        private string foodItemsFile = "FoodData.txt";
        private string sushiItemsFile = "SushiData.txt";
        private double TotalSum = 0;
        public CurrentOrder<SushiItem> CurrentSushiOrder { get; set; }
        public CurrentOrder<FoodItem> CurrentFoodItemsOrder { get; set; }
        CurrentOrder<IItem> ItemsFromFile;
        public PossibleVariants<FoodItem> FoodItemList { get; set; }
        public PossibleVariants<SushiItem> Menu { get; set; }
        public CashRegister()
        {
            CurrentSushiOrder = new CurrentOrder<SushiItem>();
            CurrentFoodItemsOrder = new CurrentOrder<FoodItem>();
            ItemsFromFile = new CurrentOrder<IItem>();
            FoodItemList = new PossibleVariants<FoodItem>();
            Menu = new PossibleVariants<SushiItem>();
            FoodItemList.ReadData(foodItemsFile);
            Menu.ReadData(sushiItemsFile);
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
