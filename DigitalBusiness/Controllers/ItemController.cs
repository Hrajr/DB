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
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace DigitalBusiness.Controllers
{
    public class ItemController : Controller
    {
        private readonly Item _itemLogic;
        private ReferenceViewModel model = new ReferenceViewModel();
        public ItemController()
        {
            _itemLogic = new Item();
        }

        [HttpGet]
        [Route("Item")]
        public IActionResult Item()
        {
            var allItems = _itemLogic.GetItem();
            model.ListOfItems.AddRange(allItems);
            return View(model);
        }

        [HttpPost]
        [Route("AddItem")]
        public IActionResult AddItem()
        {
            return View();
        }

        [HttpPost]
        [Route("SubmitItem")]
        public IActionResult SubmitItem(IFormCollection formCollection)
        {
            if (!ModelState.IsValid)
            { return View("AddItem"); }
            var newItem = new Item
            {
                Description = formCollection["Description"],
                VAT = Convert.ToInt16(formCollection["VAT"]),
                Price = Convert.ToDouble(formCollection["Price"]),
                Amount = Convert.ToInt16(formCollection["Amount"])
            };
            if (_itemLogic.AddItem(newItem))
            { return View("AddItem"); }
            return View("Item");
        }

        [HttpPost]
        public IActionResult RemoveItem(string id)
        {
            _itemLogic.RemoveItem(id);
            return RedirectToAction("Item");
        }

        [HttpPost]
        [Route("OpenItem")]
        public IActionResult OpenItem(string id)
        {
            model.SingleItem = _itemLogic.GetItemByID(id);
            return View("OpenItem", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
