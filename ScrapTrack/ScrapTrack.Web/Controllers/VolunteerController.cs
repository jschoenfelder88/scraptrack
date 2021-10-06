using ScrapTrack.Data.Models;
using ScrapTrack.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrapTrack.Web.Controllers
{
    public class VolunteerController : Controller
    {
        private readonly IVolunteerData db;

        
        public VolunteerController(IVolunteerData db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Create(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                db.Add(volunteer);
                return RedirectToAction("Details", new { id = volunteer.ID });
            }
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [ValidateAntiForgeryToken, HttpPost]
        public ActionResult Edit(Volunteer volunteer)
        {
            if (ModelState.IsValid)
            {
                db.Update(volunteer);
                return RedirectToAction("Details", new { id = volunteer.ID });
            }
            return View(volunteer);
        }
    }
}