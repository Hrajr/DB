using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DigitalBusiness.Models;
using Logic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace DigitalBusiness.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly InvoiceLogic _invoiceLogic;
        private readonly ReferenceLogic _referenceLogic;
        private ReferenceViewModel model = new ReferenceViewModel();
        public InvoiceController()
        {
            _invoiceLogic = new InvoiceLogic();
            _referenceLogic = new ReferenceLogic();
        }

        [HttpGet]
        [Route("Invoice")]
        public IActionResult Invoice()
        {
            var allInvoices = _invoiceLogic.GetInvoice();
            model.ListOfInvoices.AddRange(allInvoices);
            return View(model);
        }

        [HttpGet]
        [Route("AddInvoice")]
        public IActionResult AddInvoice()
        {
            model.ListOfReferences.AddRange(_referenceLogic.GetReference());
            return View(model);
        }

        [HttpPost]
        [Route("SubmitInvoice")]
        public IActionResult SubmitInvoice(IFormCollection formCollection)
        {
            if (!ModelState.IsValid)
            { return View("AddInvoice"); }
            var newInvoice = new Invoice
            {
                //CompanyName = formCollection["CompanyName"],
                //ContactName = formCollection["ContactName"],
                //Address = formCollection["Address"],
                //Zipcode = formCollection["Zipcode"],
                //Place = formCollection["Place"],
                //Country = formCollection["Country"],
                //PhoneNumber = formCollection["PhoneNumber"],
                //Email = formCollection["Email"],
                //Bank = formCollection["Bank"],
                //BIC = formCollection["BIC"],
                //IBAN = formCollection["IBAN"],
                //KvK = formCollection["KvK"],
                //VAT = formCollection["VAT"],
                //Doubtfull = Convert.ToBoolean(formCollection["Doubtfull"]),
                //Date = DateTime.Now,
                //Note = formCollection["Note"],
            };
            if (_invoiceLogic.AddInvoice(newInvoice))
            { return View("AddInvoice"); }
            return View("Invoice");
        }

        [HttpPost]
        public IActionResult RemoveInvoice(string id)
        {
            _invoiceLogic.RemoveInvoice(id);
            return View("Invoice");
        }

        [HttpPost]
        [Route("OpenInvoice")]
        public IActionResult OpenInvoice(string id)
        {
            model.SingleInvoice = _invoiceLogic.GetInvoiceByID(id);
            return View("OpenInvoice", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
