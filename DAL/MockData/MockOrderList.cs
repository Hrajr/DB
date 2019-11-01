using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DAL.Mock
{
    public class MockOrderList
    {
        public static MockItems Testing = new MockItems();
        public OrderList OrderListMock = new OrderList
        {
            OrderID = 1,
            Amount = 2,
            OrderItem = Testing.ItemsMock
        };
    }
}
