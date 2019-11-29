using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.SQLcontext
{
    public interface IItemContext
    {
        bool AddItem(ItemDTO item);
        bool RemoveItem(string id);
        List<ItemDTO> GetItem();
        ItemDTO GetItemByID(string id);
    }
}
