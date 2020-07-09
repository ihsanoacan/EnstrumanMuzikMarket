using BLL.Service;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_nstrumanMuzikMarket.Controllers
{
    public class AddressController : Controller
    {
        // GET: Address
        public ActionResult Index()
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            User u = Session["UserSession"] as User;

            AddressService addressService = new AddressService();
            List<Address> addressList = addressService.GetAll().ToList();
            addressList= addressList.Where(x => x.User_ID == u.ID).ToList();
            return View(addressList);
        }

        
        public ActionResult CreateAddress(int? cityId)
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }

            CityService cityService = new CityService();
            List<City> cityList = cityService.GetAll().ToList();
            ViewBag.districtList = new List<District>();

            ViewBag.cityId = cityId;

            if (cityId != null && cityId > 0)
            {
                DistrictService districtService = new DistrictService();
                List<District> dList = districtService.GetAll().ToList();
                List<District> cdList = dList.Where(x => x.City_ID == cityId).ToList();
                ViewBag.districtList = cdList;
            }   

            return View(cityList);

        }

        [HttpPost]

        public ActionResult CreateAddress(Address address)
        {

            if (Session["UserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            
            User u = Session["UserSession"] as User;
            address.User_ID = u.ID;

            try
            {
                AddressService addressService = new AddressService();

                addressService.Add(address);
                addressService.Save();
                return RedirectToAction("Index", "Address");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });

            }

        }

        public ActionResult Update(int Id)
        {
            try
            {
                //login control
                if (Session["UserSession"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }

                AddressService srv = new AddressService();
                Address addressModel = srv.GetByID(Id);

                return View(addressModel);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Edit(Address address)
        {
            try
            {
                //login control
                if (Session["UserSession"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }

                AddressService addressService = new AddressService();
                addressService.Update(address);
                addressService.Save();

                Address addressModel = addressService.GetByID(address.ID);

                return View(addressModel);
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
                
                if (Session["UserSession"] == null)
                {
                    return RedirectToAction("Index", "Login");
                }

                AddressService srv = new AddressService();
                Address addresses = srv.GetByID(Id);
                srv.Delete(Id);
                srv.Save();

                return RedirectToAction("Index","Address");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { msg = ex.Message });
            }
        }

        public ActionResult AddressSelect()
        {
            if (Session["UserSession"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
           
            User u = Session["UserSession"] as User;
            AddressService srv = new AddressService();
            List<Address> addressList = srv.GetAll().ToList();
            addressList = addressList.Where(x => x.User_ID == u.ID).ToList();

            return View(addressList);

        }


    }
}