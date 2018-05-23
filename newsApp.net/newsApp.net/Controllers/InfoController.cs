using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newsApp.net.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Show(string message)
        {
            ViewBag.Message = message;
            return View();
        }
    }
}