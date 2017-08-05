using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppInterfaces.ReadAccess;
using DomainKw;
using DomainKw.Stations;
using KletterWetter.Models;

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

        public virtual ActionResult TableDataGrid()
        {
            string stationId = GlobalConst.PROTO_STATION_ID;
            DateTime tillDate = DateTime.Now;
            DateTime fromDate = tillDate.AddDays(-14);
            StationData stationData = _weatherRA.getReadings(fromDate, tillDate, stationId);

            TableStationData tsd = new TableStationData()
            {
                WeatherRows = stationData.WeatherReadingsRaw
            };

            return PartialView(MVC.WeatherData.Views._TdTablePartial, tsd);
        }
    }
}