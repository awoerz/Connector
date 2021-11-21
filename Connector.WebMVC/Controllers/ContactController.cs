using Connector.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Connector.WebMVC.Controllers
{
    [Authorize]
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            var model = new ContactListItem[0];
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }
    }
}