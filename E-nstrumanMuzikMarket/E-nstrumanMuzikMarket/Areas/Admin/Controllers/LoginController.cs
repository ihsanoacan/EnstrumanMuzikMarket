using BLL.Service;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_nstrumanMuzikMarket.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            //login control
            if (Session["AdminUserSession"] == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            


            AdminUserService adminUserService = new AdminUserService();

            List<AdminUser> adminUsersList = adminUserService.GetAll().ToList();
            AdminUser adminUser = adminUsersList.Find(x => x.Email == email);

            if (adminUser != null)
            {
                string psw = Helper.Decrypt(adminUser.Password);
                if (psw == password)
                {
                    Session["AdminUserSession"] = adminUser;
                    return RedirectToAction("Index", "Home");
                    
                }
                else
                {

                    return RedirectToAction("Index", "Login");

                }

            }
            else
            {
                return RedirectToAction("Index", "Login");

            }


            
        }
    }
}