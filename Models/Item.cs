using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Item
    {
        public string ItemID { get; set; }
        public string Description { get; set; }
        public int VAT { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public bool InStock { get; set; }
    }
}
