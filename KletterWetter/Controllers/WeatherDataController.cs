using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KletterWetter.Controllers
{
    [Authorize]
    public partial class WeatherDataController : Controller
    {
        // GET: WeatherData
        public virtual ActionResult TableData()
        {
            ViewBag.Message = "Wetterdaten hier.";

            return View();
        }
    }
}