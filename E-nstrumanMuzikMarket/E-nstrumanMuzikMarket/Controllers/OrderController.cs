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
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            User u = Session["UserSession"] as User;
            OrderService orderService = new OrderService();
            List<Order> order = orderService.GetAll().Where(x => x.User_ID ==u.ID).ToList();
            OrderProductService opService = new OrderProductService();
            List<OrderProduct> listOrderProduct = opService.GetAll().ToList();
            ViewBag.opBag = listOrderProduct;
            
            return View(order);
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