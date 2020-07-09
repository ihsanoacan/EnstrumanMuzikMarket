using BLL.Service;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_nstrumanMuzikMarket.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cart(int pId)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ProductService service = new ProductService();
            Product product = service.GetByID(pId);

            List<Product> productList = new List<Product>();
            if (Session["Cart"] == null)
            {
                productList.Add(product);
                Session["Cart"] = productList;
            }
            else
            {
                productList=Session["Cart"] as List<Product>;
                productList.Add(product);
                Session["Cart"] = productList;
            }



            

            return RedirectToAction("Index", "Home");


        }
    }
}