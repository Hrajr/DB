using DAL.DTO;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class OrderList
    {
        public int OrderID { get; set; }
        public List<Item> OrderItem { get; set; }
        public int Amount { get; set; }

        public OrderList()
        { }

        public OrderList(OrderListDTO order)
        {
            OrderID = order.OrderID;
            OrderItem = order.OrderItem.ConvertAll(x => new Item { ItemID = x.ItemID, Price = x.Price, Description = x.Description, Amount = x.Amount, InStock = x.InStock, VAT = x.VAT });
            Amount = order.Amount;
        }

        public OrderListDTO ConvertToDTO(OrderList order)
        {
            var returnedOrder = new OrderListDTO()
            {
                OrderID = order.OrderID,
                OrderItem = order.OrderItem.ConvertAll(x => new ItemDTO { ItemID = x.ItemID, Price = x.Price, Description = x.Description, Amount = x.Amount, InStock = x.InStock, VAT = x.VAT }),
                Amount = order.Amount
            };
            return returnedOrder;
        }
    }
}
