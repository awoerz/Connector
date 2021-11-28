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
using Connector.Models.NoteModels;
using Connector.Models.ContactModels;

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
                TempData["SaveResult"] = "Your contact was created.";
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
                Notes = detail.Notes,
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

        public ActionResult AddContactToAccount()
        {
            var service = CreateContactService();
            ViewBag.Contacts = service.GetUnassignedToAccountContacts().Select(
                    c => new SelectListItem
                    {
                        Value = c.ContactId.ToString(),
                        Text = c.Name
                    }
                );
            return View(new ContactSelect());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddContactToAccount(int id, ContactSelect model)
        {
            var service = CreateContactService();
            var unAssignedContacts = service.GetUnassignedToAccountContacts();

            TempData["SomeBS"] = "More Garbarge";

            if(service.AddAccountToContact(id, model))
            {
                TempData["SaveResult"] = "You contact was updated";
                return RedirectToAction("Details", "CustomerAccount", new { id = id });
            }

            ModelState.AddModelError("", "Your contact could not be updated.");
            return View();
        }
        
        public ActionResult AddingNoteToContact(int id)
        {
            var svc = CreateContactService();
            var contact = svc.GetContactById(id);
            var model = new NoteCreate();
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddingNoteToContact(int id, NoteCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var svc = CreateContactService();

            var userId = Guid.Parse(User.Identity.GetUserId());
            var noteService = new NoteService(userId);

            if (noteService.CreateNote(model))
            {
                var noteIdToPass = noteService.GetNotes().ToList().Last().NoteId;
                svc.AddNote(id, noteIdToPass);
                TempData["SaveResult"] = "Your contact was created.";
                return RedirectToAction("Details", new { id = id});
            }

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
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