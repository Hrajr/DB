using System;
using System.Collections.Generic;
using System.Text;
using DAL.SQLcontext;
using Models;

namespace Logic
{
    public class InvoiceLogic
    {
        private readonly IInvoiceContext _context;

        public InvoiceLogic()
        {
            _context = new InvoiceContext();
        }

        public bool AddInvoice(Invoice invoice)
        {
            return _context.AddInvoice(invoice);
        }

        public bool RemoveInvoice(string id)
        {
            return _context.RemoveInvoice(id);
        }

        public bool EditInvoice(Invoice invoice)
        {
            return _context.EditInvoice(invoice);
        }

        public List<Invoice> GetInvoice()
        {
            return _context.GetInvoice();
        }

        public Invoice GetInvoiceByID(string id)
        {
            return _context.GetInvoiceByID(id);
        }
    }
}
