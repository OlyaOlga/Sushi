using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiEntityFramework
{
    public class SushiOrder
    {
        public List<SushiItem> SushiOrders { get; set; }

        public SushiOrder()
        {
            SushiOrders = new List<SushiItem>();
        }
    }
}
