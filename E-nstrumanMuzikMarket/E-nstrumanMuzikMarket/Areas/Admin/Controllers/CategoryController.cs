using BLL.Service;
using DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_nstrumanMuzikMarket.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            //login control
            if (Session["AdminUserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            CategoryService srv = new CategoryService();
            List<Category> CategoryList = srv.GetAll().ToList();

            return View(CategoryList);
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
        public ActionResult Add(Category category,HttpPostedFileBase file)
        {
            try
            {
                //login control
                if (Session["AdminUserSession"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }
                string imagePath = string.Empty;
                if (file != null)
                {
                    string rootFolder = "/Files";
                    string path = Server.MapPath("~" + rootFolder + "/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    file.SaveAs(path + Path.GetFileName(file.FileName));
                    imagePath = rootFolder + "/" + file.FileName;

                }


                CategoryService srv = new CategoryService();
                category.ImagePath = imagePath;
                srv.Add(category);
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
            try
            {
                //login control
                if (Session["AdminUserSession"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }

                CategoryService srv = new CategoryService();
                Category categoryModel = srv.GetByID(Id);

                return View(categoryModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(Category category, HttpPostedFileBase file)
        {
            try
            {
                //login control
                if (Session["AdminUserSession"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }

                string imagePath = string.Empty;
                if (file != null)
                {
                    string rootFolder = "/Files";
                    string path = Server.MapPath("~" + rootFolder + "/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    file.SaveAs(path + Path.GetFileName(file.FileName));
                    imagePath = rootFolder + "/" + file.FileName;

                }


                CategoryService categoryService = new CategoryService();
                category.ImagePath = imagePath;
                categoryService.Update(category);
                categoryService.Save();

                Category categoryModel = categoryService.GetByID(category.ID);

                return View(categoryModel);
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

                CategoryService srv = new CategoryService();
                Category categoryModel = srv.GetByID(Id);
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