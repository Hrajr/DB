using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;

namespace DigitalBusiness.Models
{
    public class ReferenceViewModel
    {
        public List<ReferenceLogic> ListOfReferences = new List<ReferenceLogic>();
        public List<InvoiceLogic> ListOfInvoices = new List<InvoiceLogic>();
        public List<Item> ListOfItems = new List<Item>();
        public ReferenceLogic SingleReference = new ReferenceLogic();
        public InvoiceLogic SingleInvoice = new InvoiceLogic();
        public Item SingleItem = new Item();
    }
}
