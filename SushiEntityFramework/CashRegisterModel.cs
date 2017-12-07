using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiEntityFramework
{
    public class CashRegisterModel
    {
        public SushiContext SushiContext { get; set; }

        public CashRegisterModel()
        {
            Console.WriteLine();
        }
        public List<SushiItem> ReadMenu()
        {
            List<SushiItem> menuSushi = new List<SushiItem>();
            using (var db = new SushiContext())
            {
                var sushi = from s in db.Menu
                            select s;
                foreach (var item in sushi)
                {
                    menuSushi.Add(item);
                }
            }
            return menuSushi;
        }

        public void AddListOfItems(List<Order> sushiItems)
        {
            using (var context = new SushiContext())
            {
                for (int i = 0; i < sushiItems.Count; ++i)
                { 
                    context.Orders.Add(new Order {SushiName = sushiItems[i].SushiName, SushiPrice = sushiItems[i].SushiPrice});
                }
                context.SaveChanges();
            }
        }

        public double CountTotalSum()
        {
            double res;
            using (var db = new SushiContext())
            {
                var sushi = (from s in db.Orders
                            select s).Sum(s=> s.SushiPrice);
                res = sushi;
            }
            return res;
        }
    }
}
