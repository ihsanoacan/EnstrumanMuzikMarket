using BLL.Service;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_nstrumanMuzikMarket.Areas.Admin.Controllers
{
    public class CityController : Controller
    {
        // GET: Admin/City
        public ActionResult Index()
        {
            //login control
            if (Session["AdminUserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            CityService srv = new CityService();
            List<City> CityList = srv.GetAll().ToList();
           
            return View(CityList);
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
        public ActionResult Add(City City)
        {
            try
            {
                //login control
                if (Session["AdminUserSession"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }

                CityService srv = new CityService();
                srv.Add(City);
                srv.Save();

                return View();
            }
            catch(Exception ex)
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

                CityService srv = new CityService();
                City cityModel = srv.GetByID(Id);

                return View(cityModel);
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(City city)
        {
            try
            {
                //login control
                if (Session["AdminUserSession"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }

                CityService cityService = new CityService();
                cityService.Update(city);
                cityService.Save();

                City cityModel = cityService.GetByID(city.ID);

                return View(cityModel);
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

                CityService srv = new CityService();
                City cityModel = srv.GetByID(Id);
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