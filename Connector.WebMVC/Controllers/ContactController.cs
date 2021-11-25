using Connector.Models;
using Connector.Services;
using Connector.WebMVC.Models;
using Connector.Data;
using Microsoft.AspNet.Identity;
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
        //View All Cotnacts
        // GET: Contact
        public ActionResult Index()
        {
            var service = CreateContactService();
            var model = service.GetContacts();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //Create a Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateContactService();

            if (service.CreateContact(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Contact could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateContactService();
            var model = svc.GetContactById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateContactService();
            var detail = service.GetContactById(id);
            var model = new ContactEdit
            {
                ContactId = detail.ContactId,
                Name = detail.Name,
                Email = detail.Email,
                PhoneNumber = detail.PhoneNumber,
                NoteIds = detail.NoteIds,
                LastContacted = detail.LastContacted,
                MyProperty = detail.MyProperty
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ContactEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.ContactId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateContactService();

            if(service.UpdateContact(model))
            {
                TempData["SaveResult"] = "You contact was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your contact could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateContactService();
            var model = svc.GetContactById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateContactService();

            service.DeleteContact(id);

            TempData["SaveResult"] = "Your contact was deleted";
            return RedirectToAction("Index");
        }

        private ContactService CreateContactService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ContactService(userId);
            return service;
        }
    }
}