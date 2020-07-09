using BLL.Service;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_nstrumanMuzikMarket.Areas.Admin.Controllers
{
    public class DistrictController : Controller
    {
        // GET: Admin/District
        public ActionResult Index()
        {
            //login control
            if (Session["AdminUserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            DistrictService srv = new DistrictService();
            List<District> districtList = srv.GetAll().ToList();


            return View(districtList);


        }
        public ActionResult Add()
        {
            //login control
            if (Session["AdminUserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            CityService srv = new CityService();
            List<City> City = srv.GetAll().ToList();
            return View(City);
        }


        [HttpPost]
        public ActionResult Add(District district)
        {
            CityService srvCity = new CityService();
            List<City> City = srvCity.GetAll().ToList();

            DistrictService srv = new DistrictService();
            srv.Add(district);
            srv.Save();
            return View(City);
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
                DistrictService srv = new DistrictService();
                District districtModel = srv.GetByID(Id);

                CityService srvCity = new CityService();
                List<City> City = srvCity.GetAll().ToList();
                ViewBag.cityList = City;

                return View(districtModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(District district)
        {
            try
            {
                //login control
                if (Session["AdminUserSession"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }

                DistrictService districtService = new DistrictService();
                districtService.Update(district);
                districtService.Save();

                District distrctModel = districtService.GetByID(district.ID);
                CityService srvCity = new CityService();
                List<City> City = srvCity.GetAll().ToList();
                ViewBag.cityList = City;

                return View(distrctModel);
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

                DistrictService srv = new DistrictService();
                District districtModel = srv.GetByID(Id);
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