using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SushiEntityFramework.Annotations;

namespace SushiEntityFramework
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string SushiName { get; set; }

        public double SushiPrice { get; set; }
    }
}
