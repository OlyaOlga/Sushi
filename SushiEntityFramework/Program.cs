using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
           
            List<SushiItem> menuSushi = new List<SushiItem>();
            using (var db = new SushiContext())
            {
                var sushi = from s in db.Menu
                    select s;
                foreach (var item in sushi)
                {
                    menuSushi.Add(item);
                    //Console.WriteLine((item as SushiItem).Name);
                }
            }

            foreach (var item  in menuSushi)
            {
                Console.WriteLine(item.Name);
            }
                Console.ReadKey();
        }
    }
}
