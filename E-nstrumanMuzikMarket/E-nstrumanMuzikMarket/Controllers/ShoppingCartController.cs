using BLL.Service;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_nstrumanMuzikMarket.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            List<Product> productList = new List<Product>();
            productList = Session["Cart"] as List<Product>;
            return View(productList);

        }
    }
}