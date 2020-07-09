using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_nstrumanMuzikMarket.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index(string msg)
        {
            ViewBag.Message = msg;
            return View();
        }
    }
}