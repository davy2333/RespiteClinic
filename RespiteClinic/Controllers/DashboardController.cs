using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RespiteClinic.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }

        public new ActionResult Profile()
        {
            ViewBag.Message = "Sample page for Profile.";

            return View();
        }

        public ActionResult Tables()
        {
            ViewBag.Message = "Sample page for Tables.";

            return View();
        }
    }
}