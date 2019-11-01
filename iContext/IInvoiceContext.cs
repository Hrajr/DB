using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace DAL.SQLcontext
{
    public interface IInvoiceContext
    {
        bool AddInvoice(Invoice invoice);
        bool RemoveInvoice(string id);
        bool EditInvoice(Invoice invoice);
        List<Invoice> GetInvoice();
        Invoice GetInvoiceByID(string id);
    }
}
