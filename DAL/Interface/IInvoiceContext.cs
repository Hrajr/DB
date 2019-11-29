using DAL.DTO;
using System.Collections.Generic;

namespace DAL.SQLcontext
{
    public interface IInvoiceContext
    {
        bool AddInvoice(InvoiceDTO invoice);
        bool RemoveInvoice(string id);
        bool EditInvoice(InvoiceDTO invoice);
        List<InvoiceDTO> GetInvoice();
        InvoiceDTO GetInvoiceByID(string id);
    }
}
