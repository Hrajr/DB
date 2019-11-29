using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Mock
{
    public class MockOrderList
    {
        public static MockItems Testing = new MockItems();
        public OrderListDTO OrderListMock = new OrderListDTO
        {
            OrderID = 1,
            Amount = 2,
            OrderItem = Testing.ItemsMock
        };
    }
}
