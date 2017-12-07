using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiEntityFramework
{
    public class CashRegisterModel
    {
        public UnitOfWork UnitOfWork { get; set; }

        public CashRegisterModel()
        {
            UnitOfWork = new UnitOfWork();
        }
        public List<SushiItem> ReadMenu()
        {
            return UnitOfWork.SushiRepositoriy.GetSushiItems().ToList(); 
        }

        public void AddListOfItems(List<Order> sushiItems)
        {
            for (int i = 0; i < sushiItems.Count; ++i)
            {
                UnitOfWork.OrderRepository.InsertOrder(new Order { SushiName = sushiItems[i].SushiName, SushiPrice = sushiItems[i].SushiPrice });
            }
            UnitOfWork.Save();
        }

        public double CountTotalSum()
        {
            double res;
            var sushi = (from s in UnitOfWork.OrderRepository.GetOrders()
                         select s).Sum(s => s.SushiPrice);
            res = sushi;
            return res;
        }
    }
}
