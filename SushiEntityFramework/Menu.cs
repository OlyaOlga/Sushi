using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiEntityFramework
{
    public class Menu
    {
        public List<SushiOrder> SushiMenu { get; set; }

        public Menu()
        {
            SushiMenu = new List<SushiOrder>();
        }
    }
}
