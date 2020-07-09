using BLL.Service;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_nstrumanMuzikMarket.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(int id)
        {
           
            
            ProductService srv = new ProductService();
            List<Product> productlist = srv.GetAll().Where(x => x.Category_ID == id).ToList();



            return View(productlist);
        }
        public ActionResult Detail(int id)
        {
            ProductService srv = new ProductService();
            Product product = srv.GetByID(id);



            return View(product);
        }

        
    }
}