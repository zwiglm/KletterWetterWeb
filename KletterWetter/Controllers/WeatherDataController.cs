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
    
    public partial class WeatherDataController : Controller
    {
        private IWeatherRA _weatherRA;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="weatherRA"></param>
        public WeatherDataController(IWeatherRA weatherRA)
        {
            _weatherRA = weatherRA;
        }


        // GET: WeatherData for Table presentation
        [Authorize]
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

            TableStationData tsd = new TableStationData(fromDate, tillDate, stationData.WeatherReadingsRaw);

            return PartialView(MVC.WeatherData.Views._TdTablePartial, tsd);
        }


        // GET: WeatherData for Demo-Charts presentation
        public virtual ActionResult ChartData()
        {
            ViewBag.Message = "Wetterdaten hier.";

            string stationId = GlobalConst.PROTO_STATION_ID;
            DateTime tillDate = DateTime.Now;
            DateTime fromDate = tillDate.AddDays(-7);
            StationData stationData = _weatherRA.getReadings(fromDate, tillDate, stationId);

            TableStationData tsd = new TableStationData(fromDate, tillDate, stationData.WeatherReadingsRaw);


            return View(MVC.WeatherData.Views.ChartData, tsd);
        }
    }
}