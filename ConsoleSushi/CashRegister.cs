using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ConsoleSushi.Annotations;

namespace ConsoleSushi
{
    public class CashRegister:
        IFileActions,
        INotifyPropertyChanged
    {
        private double _totalSum;
        private string foodItemsFile = "FoodData.txt";
        private string sushiItemsFile = "SushiData.txt";
        
        public double TotalSum
        {
            get
            {
                return _totalSum;
            }
            set
            {
                _totalSum = value;
                OnPropertyChanged("TotalSum");
            }
        }
        public CurrentOrder<SushiItem> CurrentSushiOrder { get; set; }
        public CurrentOrder<FoodItem> CurrentFoodItemsOrder { get; set; }
        private CurrentOrder<IItem> ItemsFromFile;
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
            TotalSum = 0;
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

       
        public void SaveData<T>(CurrentOrder<T> data) where T : IItem
        {
            for (int i = 0; i < data.Order.Count; ++i)
            {
                ItemsFromFile.Order.Add(data.Order[i] as ConsoleSushi.OrderEntity<ConsoleSushi.IItem>);
            }
            if (typeof (T) == typeof (SushiItem))
            {
                TotalSum += data.TotalSum;
            }
            else
            {
                TotalSum-= data.TotalSum;
            }
        }

        public void ClearData<T>(CurrentOrder<T> data)where T : IItem
        {
            data.Order.Clear();
            data.TotalSum = 0;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
