using DTO;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.DTO
{
    public class InvoiceDTO
    {
        public string InvoiceNumber { get; set; }
        public InvoiceType TypeOfInvoice { get; set; }
        public ReferenceDTO InvoiceReference { get; set; }
        public OrderListDTO InvoiceOrder { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public UserDTO InvoiceUser { get; set; }
        public bool PaymentStatus { get; set; } = false;
    }
}
