using System;
using Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalBusiness.Models
{
    public class ReferenceViewModel
    {
        public List<Reference> ListOfReferences = new List<Reference>();
        public List<Invoice> ListOfInvoices = new List<Invoice>();
        public List<Item> ListOfItems = new List<Item>();
        public Reference SingleReference = new Reference();
        public Invoice SingleInvoice = new Invoice();
        public Item SingleItem = new Item();
    }
}
