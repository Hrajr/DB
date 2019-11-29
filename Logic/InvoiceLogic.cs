using System;
using System.Collections.Generic;
using System.Text;
using DAL.DTO;
using DAL.SQLcontext;
using Models;

namespace Logic
{
    public class InvoiceLogic
    {
        internal string InvoiceNumber { get; set; }
        internal InvoiceType TypeOfInvoice { get; set; }
        internal ReferenceLogic InvoiceReference { get; set; }
        internal OrderList InvoiceOrder { get; set; }
        internal DateTime InvoiceDate { get; set; }
        internal DateTime PayementDate { get; set; }
        internal UserLogic InvoiceUser { get; set; }
        internal bool PaymentStatus { get; set; } = false;

        internal readonly IInvoiceContext _context;
        internal readonly IReferenceContext _refContext;
        internal readonly ReferenceLogic _referenceLogic;
        internal readonly OrderList _orderList;
        internal readonly UserLogic _userLogic;

        public InvoiceLogic()
        {
            _context = new InvoiceContext();
            _refContext = new ReferenceContext();
        }

        public InvoiceLogic(InvoiceDTO invoice)
        {
            InvoiceNumber = invoice.InvoiceNumber;
            TypeOfInvoice = invoice.TypeOfInvoice;
            InvoiceReference = new ReferenceLogic(invoice.InvoiceReference);
            InvoiceOrder = new OrderList(invoice.InvoiceOrder);
            InvoiceDate = invoice.InvoiceDate;
            PayementDate = invoice.PaymentDate;
            InvoiceUser = new UserLogic(invoice.InvoiceUser);
            PaymentStatus = invoice.PaymentStatus;
        }

        public InvoiceDTO ConvertToDTO(InvoiceLogic invoice)
        {
            var returnedInvoice = new InvoiceDTO()
            {
                InvoiceNumber = invoice.InvoiceNumber,
                TypeOfInvoice = invoice.TypeOfInvoice,
                InvoiceReference = _referenceLogic.ConvertToDTO(invoice.InvoiceReference),
                InvoiceOrder = _orderList.ConvertToDTO(invoice.InvoiceOrder),
                InvoiceDate = invoice.InvoiceDate,
                PaymentDate = invoice.PayementDate,
                InvoiceUser = _userLogic.ConvertToDTO(invoice.InvoiceUser),
                PaymentStatus = invoice.PaymentStatus
            };
            return returnedInvoice;
        }

        public bool AddInvoice(InvoiceLogic invoice, string referenceID, OrderList order)
        {
            InvoiceOrder = order;
            InvoiceReference = new ReferenceLogic(_refContext.GetReferenceByID(referenceID));
            return _context.AddInvoice(ConvertToDTO(invoice));
        }

        public bool RemoveInvoice(string id)
        {
            return _context.RemoveInvoice(id);
        }

        public bool EditInvoice(InvoiceLogic invoice)
        {
            return _context.EditInvoice(ConvertToDTO(invoice));
        }

        public List<InvoiceLogic> GetInvoice()
        {
            return _context.GetInvoice().ConvertAll(x => new InvoiceLogic { InvoiceNumber = x.InvoiceNumber, TypeOfInvoice = x.TypeOfInvoice, InvoiceReference = new ReferenceLogic(x.InvoiceReference), InvoiceOrder = new OrderList(x.InvoiceOrder), InvoiceUser = new UserLogic(x.InvoiceUser), InvoiceDate = x.InvoiceDate, PayementDate = x.InvoiceDate, PaymentStatus = x.PaymentStatus });
        }

        public InvoiceLogic GetInvoiceByID(string id)
        {
            return new InvoiceLogic(_context.GetInvoiceByID(id));
        }
    }
}
