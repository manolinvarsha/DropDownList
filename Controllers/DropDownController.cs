using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CascadingDropDownList;

namespace CascadingDropDownList.Controllers
{
    public class DropDownController : Controller
    {
        // GET: DropDown
        public ActionResult Index()
        {
            SampleDBEntities sd = new SampleDBEntities();
            ViewBag.CountryList = new SelectList(GetCountryList(), "Cid", "Cname");
            return View();
        }
        public List<Country>GetCountryList()
        {
            SampleDBEntities sd = new SampleDBEntities();
            List<Country> countries = sd.Countries.ToList();
            return countries;
        }
        public ActionResult GetStateList(int Cid)
        {
            SampleDBEntities sd = new SampleDBEntities();
            List<State> selectList = sd.States.Where(x => x.Cid == Cid).ToList();
            ViewBag.Slist = new SelectList(selectList, "Sid", "Sname");
            return PartialView("DisplayStates");
        }
        public ActionResult GetCityList(int Sid)
        {
            SampleDBEntities sd = new SampleDBEntities();
            List<City> selectList = sd.Cities.Where(x => x.Sid == Sid).ToList();
            ViewBag.Citylist = new SelectList(selectList, "Cityid", "CityName");
            return PartialView("DisplayCities");
        }
    }
}