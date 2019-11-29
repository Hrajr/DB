using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class OrderList
    {
        public int OrderID { get; set; }
        public List<Item> OrderItem { get; set; }
        public int Amount { get; set; }
    }
}
