using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_nstrumanMuzikMarket.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            //login control
            if (Session["AdminUserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}