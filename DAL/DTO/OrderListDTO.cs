using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public class OrderListDTO
    {
        public int OrderID { get; set; }
        public List<ItemDTO> OrderItem { get; set; }
        public int Amount { get; set; }
    }
}
