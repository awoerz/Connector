using Connector.Models.AccountTaskModels;
using Connector.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Connector.WebMVC.Controllers
{
    public class AccountTaskController : Controller
    {
        // GET: AccountTask
        public ActionResult Index()
        {
            var service = CreateAccountTaskService();
            var model = service.GetAccountTasks();
            return View(model);
        }
        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerAccountService(userId);
            ViewBag.CustomerAccounts = service.GetCustomerAccounts().Select(
                    c => new SelectListItem
                    {
                        Value = c.CustomerAccountId.ToString(),
                        Text = c.Name
                    }
                );
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AccountTaskCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateAccountTaskService();

            if (service.CreateAccountTask(model))
            {
                TempData["SaveResult"] = "Your task was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Contact could not be created.");

            return View(model);
        }
        private AccountTaskService CreateAccountTaskService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AccountTaskService(userId);
            return service;
        }
    }
}