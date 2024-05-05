﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }
    }

}
