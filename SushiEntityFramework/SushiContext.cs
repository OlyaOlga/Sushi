﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SushiEntityFramework
{
    public class SushiContext:
        DbContext
    {
        public DbSet<SushiItem> Menu { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
