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
            var userId = Guid.Parse(User.Identity.GetUserId());
            var customerAccountService = new CustomerAccountService(userId);
            var model = service.GetAccountTasks();
            foreach(var task in model)
            {
                task.CustomerAccount = customerAccountService.GetCustomerAccountById(task.CustomerAccountId);
            }

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
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAccountTaskService();
            var model = svc.GetAccountTaskById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAccountTaskService();

            service.DeleteTaskAccount(id);

            TempData["SaveResult"] = "Your contact was deleted";
            return RedirectToAction("Index");
        }

        public ActionResult ToggleTask(int id)
        {
            var service = CreateAccountTaskService();
            if (service.ToggleAccountTaskComplete(id))
            {
                TempData["SaveResult"] = "You task was updated";
                return RedirectToAction("Index");
            };

            TempData["SaveResult"] = "Something went wrong and task could not be updated.";
            return RedirectToAction("Index");
        }

        private AccountTaskService CreateAccountTaskService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AccountTaskService(userId);
            return service;
        } 
    
    }
}