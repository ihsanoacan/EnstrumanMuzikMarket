using BLL.Service;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_nstrumanMuzikMarket.Areas.Admin.Controllers
{
    public class AdminUserController : Controller
    {
        // GET: Admin/AdminUser
        public ActionResult Index()
        {
            //login control
            if (Session["AdminUserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            

            AdminUserService srv = new AdminUserService();
            List<AdminUser> AdminList = srv.GetAll().ToList();

            return View(AdminList);
        }
        public ActionResult Add()
        {
            //login control
            if (Session["AdminUserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Add(AdminUser adminUser)
        {
            try
            {
                //login control
                if (Session["AdminUserSession"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                AdminUserService srv = new AdminUserService();
                adminUser.Password = Helper.Crypt(adminUser.Password);
                srv.Add(adminUser);
                srv.Save();

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });
            }




        }


        public ActionResult Edit(int Id)
        {
            try { 
            //login control
            if (Session["AdminUserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            AdminUserService srv = new AdminUserService();
                AdminUser adminUserModel = srv.GetByID(Id);
                adminUserModel.Password = Helper.Decrypt(adminUserModel.Password);

                return View(adminUserModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(AdminUser adminUser)
        {
            try
            {
                //login control
                if (Session["AdminUserSession"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }

                AdminUserService adminUserService = new AdminUserService();
                adminUser.Password = Helper.Crypt(adminUser.Password);
                adminUserService.Update(adminUser);
                adminUserService.Save();

                AdminUser adminUserModel = adminUserService.GetByID(adminUser.ID);
                adminUserModel.Password = Helper.Decrypt(adminUserModel.Password);

                return View(adminUserModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });
            }
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                //login control
                if (Session["AdminUserSession"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }

                AdminUserService srv = new AdminUserService();
                AdminUser adminUserModel = srv.GetByID(Id);
                srv.Delete(Id);
                srv.Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });
            }
        }
    }
}