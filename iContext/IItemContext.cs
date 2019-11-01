using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLcontext
{
    public interface IItemContext
    {
        bool AddItem(Item item);
        bool RemoveItem(string id);
        List<Item> GetItem();
        Item GetItemByID(string id);
    }
}
