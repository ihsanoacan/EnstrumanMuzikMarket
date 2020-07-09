using BLL.Service;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_nstrumanMuzikMarket.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index(int addressId)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            ViewBag.addressId = addressId;

            return View();
        }

        [HttpPost]
        public ActionResult Index(string NameOnCard, string CardNumber, string Month, string Year, string CVV,int AddressId)
        {

            if (Session["UserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            User u = Session["UserSession"] as User;
            Order order = new Order();
            OrderService orderService = new OrderService();
            //ödeme yapılmıs gibi bi ödeme referens no generate ediliyor
            string code = CardNumber + Month + Year + CVV;
            string paymentRefNo = Helper.Crypt(code);

            order.Address_ID = AddressId;
            order.OrderDate = DateTime.Now;
            order.User_ID = u.ID;
            order.PaymentRefNo = paymentRefNo;
            order.OrderNo = Guid.NewGuid();
            order.ShippingNo = Guid.NewGuid();
            orderService.Add(order);
            orderService.Save();

            List<Product> p = Session["Cart"]as List<Product>;
            OrderProductService orderProductService = new OrderProductService();
            foreach (Product item in p)
            {
                OrderProduct orderProduct = new OrderProduct();
                orderProduct.Order_ID = order.ID;
                orderProduct.Product_ID = item.ID;
                orderProduct.ImagePath = item.ImagePath;
                orderProduct.ProductName = item.ProductName;
                orderProductService.Add(orderProduct);
                orderProductService.Save();
                
            }

            
           
            return View();


            //todo: order tablosu  alanları belirlenecek ve order tablosu create edilecek. sonra aorderservice yazılacak. daha sonra order create edilecek

        }

    }

   



   
}