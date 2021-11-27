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
    public class NoteController : Controller
    {
        // GET: Note
        public ActionResult Index()
        {
            var service = CreateNoteService();
            var model = service.GetNotes();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        //Create A Note
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NoteCreate model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateNoteService();

            if(service.CreateNote(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Note could not be created.");

            return View(model);
        }

        public ActionResult CreateForContact(int id, NoteCreate model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateNoteService();

            if(service.CreateNoteForContact(id, model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Details", "Contact", new { id = id });
            }

            ModelState.AddModelError("", "Your not could not be created.");
            return View(model);
        }


        private NoteService CreateNoteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NoteService(userId);
            return service;
        }
    }
}