using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DAL.Mock
{
    public class MockInvoice
    {
        public static MockReference TestMockReference = new MockReference();
        public static MockOrderList TestMockOrderList = new MockOrderList();
        public static MockUser TestMockUser = new MockUser();
        public Invoice InvoiceMock = new Invoice
        {
            InvoiceNumber = "TestInvoiceNumber",
            TypeOfInvoice = InvoiceType.Purchase,
            InvoiceReference = TestMockReference.ReferenceMock,
            InvoiceOrder = TestMockOrderList.OrderListMock,
            InvoiceDate = DateTime.Now.Date,
            PayementDate = DateTime.Now.Date.AddDays(3),
            InvoiceUser = TestMockUser.UserMock,
            PaymentStatus = false
        };
    }
}
