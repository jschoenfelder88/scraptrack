using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrapTrack.Web.Controllers
{
    public class ReportController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}