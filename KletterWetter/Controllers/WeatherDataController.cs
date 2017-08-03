using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppInterfaces.ReadAccess;

namespace KletterWetter.Controllers
{
    [Authorize]
    public partial class WeatherDataController : Controller
    {
        private IWeatherRA _weatherRA;

        public WeatherDataController(IWeatherRA weatherRA)
        {
            _weatherRA = weatherRA;
        }


        // GET: WeatherData
        public virtual ActionResult TableData()
        {
            ViewBag.Message = "Wetterdaten hier.";

            return View();
        }
    }
}