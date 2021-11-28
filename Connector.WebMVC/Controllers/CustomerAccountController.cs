using Connector.Models.CustomerAccountModels;
using Connector.Models.NoteModels;
using Connector.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Connector.WebMVC.Controllers
{
    public class CustomerAccountController : Controller
    {
        // GET: CustomerAccount
        public ActionResult Index()
        {
            var service = CreateCustomerAccountService();
            var model = service.GetCustomerAccounts();
            return View(model);
        }
        //GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerAccountCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateCustomerAccountService();

            if (service.CreateCustomerAccount(model))
            {
                TempData["SaveResult"] = "Your Customer Account was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Customer Account could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateCustomerAccountService();
            var model = svc.GetCustomerAccountById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var svc = CreateCustomerAccountService();
            var detail = svc.GetCustomerAccountById(id);
            var model = new CustomerAccountEdit
            {
                CustomerAccountId = detail.CustomerAccountId,
                Name = detail.Name
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerAccountEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerAccountId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCustomerAccountService();

            if (service.UpdateCustomerAccount(model))
            {
                TempData["SaveResult"] = "You account was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your account could not be updated.");
            return View();
        }
        public ActionResult AddingNoteToCustomerAccount(int id)
        {
            var svc = CreateCustomerAccountService();
            var contact = svc.GetCustomerAccountById(id);
            var model = new NoteCreate();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddingNoteToCustomerAccount(int id, NoteCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var svc = CreateCustomerAccountService();

            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new NoteService(userId);

            if (noteService.CreateNote(model))
            {
                var noteIdToPass = noteService.GetNotes().ToList().Last().NoteId;
                svc.AddNote(id, noteIdToPass);
                TempData["SaveResult"] = "Your contact was created.";
                return RedirectToAction("Details", new { id = id });
            }

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCustomerAccountService();
            var model = svc.GetCustomerAccountById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCustomerAccountService();

            service.DeleteCustomerAccount(id);

            TempData["SaveResult"] = "Your contact was deleted";
            return RedirectToAction("Index");
        }
        private CustomerAccountService CreateCustomerAccountService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerAccountService(userId);
            return service;
        }
    }
}