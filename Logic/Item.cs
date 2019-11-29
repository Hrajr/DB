using System;
using System.Collections.Generic;
using System.Text;
using DAL.SQLcontext;
using DTO;
using Models;

namespace Logic
{
    public class Item
    {
        public string ItemID { get; set; }
        public string Description { get; set; }
        public int VAT { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public bool InStock { get; set; }

        private readonly IItemContext _context;

        public Item()
        {
            _context = new ItemContext();
        }

        public Item(ItemDTO item)
        {
            ItemID = item.ItemID;
            Description = item.Description;
            VAT = item.VAT;
            Amount = item.Amount;
            InStock = item.InStock;
        }

        private ItemDTO ConvertToDTO(Item item)
        {
            var convertedItem = new ItemDTO()
            {
                ItemID = item.ItemID,
                Description = item.Description,
                VAT = item.VAT,
                Price = item.Price,
                Amount = item.Amount,
                InStock = item.InStock
            };
            return convertedItem;
        }

        public bool AddItem(Item item)
        {
            return _context.AddItem(ConvertToDTO(item));
        }

        public bool RemoveItem(string id)
        {
            return _context.RemoveItem(id);
        }

        public List<Item> GetItem()
        {
            return _context.GetItem().ConvertAll(x => new Item { ItemID = x.ItemID, Price = x.Price, Description = x.Description, Amount = x.Amount, InStock = x.InStock, VAT = x.VAT });
        }

        public Item GetItemByID(string id)
        {
            return new Item(_context.GetItemByID(id));
        }
    }
}
