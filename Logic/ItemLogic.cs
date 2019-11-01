using System;
using System.Collections.Generic;
using System.Text;
using DAL.SQLcontext;
using Models;

namespace Logic
{
    public class ItemLogic
    {
        private readonly IItemContext _context;

        public ItemLogic()
        {
            _context = new ItemContext();
        }

        public bool AddItem(Item item)
        {
            return _context.AddItem(item);
        }

        public bool RemoveItem(string id)
        {
            return _context.RemoveItem(id);
        }

        public List<Item> GetItem()
        {
            return _context.GetItem();
        }

        public Item GetItemByID(string id)
        {
            return _context.GetItemByID(id);
        }
    }
}
