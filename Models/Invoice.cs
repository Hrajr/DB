﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Invoice
    {
        public string InvoiceNumber { get; set; }
        public InvoiceType TypeOfInvoice { get; set; }
        public Reference InvoiceReference { get; set; }
        public OrderList InvoiceOrder { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime PayementDate { get; set; }
        public User InvoiceUser { get; set; }
        public bool PaymentStatus { get; set; } = false;
    }
}
