using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSushi
{
    public class PossibleBuy:
         IChangeDataContainers<FoodItem>
    {
        public List<FoodItem> PossibleBuyList { get; }

        public PossibleBuy()
        {
            PossibleBuyList  = new List<FoodItem>();
        }
        public void AddItem(FoodItem item)
        {
            PossibleBuyList.Add(item);
        }
        public void RemoveItem(FoodItem item)
        {
            PossibleBuyList.Remove(item);
        }
        public override string ToString()
        {
            string res = string.Empty;
            foreach (var item in PossibleBuyList)
            {
                res += item;
                res += '\n';
            }
            return res;
        }
    }
}
