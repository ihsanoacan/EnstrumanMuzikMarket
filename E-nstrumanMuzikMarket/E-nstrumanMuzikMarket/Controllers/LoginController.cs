using BLL.Service;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_nstrumanMuzikMarket.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult Index(string Email,string Password)
        {
            UserService userService = new UserService();
            List<User> userList = userService.GetAll().ToList();
            User user = userList.Find(x => x.Email == Email);

            if (user != null)
            {
                string psw = Helper.Decrypt(user.Password);
                if (psw == Password)
                {
                    Session["UserSession"] = user;
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

        public ActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAccount(User user)
        {
            try
            {
                UserService userService = new UserService();
                user.Password = Helper.Crypt(user.Password);
                userService.Add(user);
                userService.Save();
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });

            }

            
            
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

    }
    
}