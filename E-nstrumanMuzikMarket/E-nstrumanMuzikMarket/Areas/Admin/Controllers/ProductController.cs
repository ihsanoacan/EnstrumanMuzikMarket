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
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index()
        {
            //login control
            if (Session["AdminUserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ProductService srv = new ProductService();
            List<Product> productList = srv.GetAll().ToList();


            return View(productList);
        }
        public ActionResult Add()
        {
            //login control
            if (Session["AdminUserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            CategoryService srv = new CategoryService();
            List<Category> category = srv.GetAll().ToList();
            return View(category);
        }



        [HttpPost]
        public ActionResult Add(Product product, HttpPostedFileBase file)
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


                CategoryService srvcategory = new CategoryService();
                List<Category> category = srvcategory.GetAll().ToList();
                

                ProductService srv = new ProductService();
                
                product.ImagePath = imagePath;
                srv.Add(product);
                srv.Save();

                return View(category);
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

                ProductService srv = new ProductService();
                Product productModel = srv.GetByID(Id);

                CategoryService srvCategory = new CategoryService();
                List<Category> category = srvCategory.GetAll().ToList();
                ViewBag.categoryList = category;
                return View(productModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase file)
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


                ProductService productService = new ProductService();
                product.ImagePath = imagePath;
                productService.Update(product);
                productService.Save();

                Product productModel = productService.GetByID(product.ID);
                CategoryService srvcategory = new CategoryService();
                List<Category> Category = srvcategory.GetAll().ToList();
                ViewBag.categoryList = Category;

                return View(productModel);
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

                ProductService srv = new ProductService();
                Product productModel = srv.GetByID(Id);
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