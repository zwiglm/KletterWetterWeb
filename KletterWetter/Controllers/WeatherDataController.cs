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
        private static int DAYS_BACK_FOR_TABLE = -14;
        private static int DAYS_BACK_FOR_CHARTS = -7;
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
            DateTime tillDate = DateTime.Now;
            DateTime fromDate = tillDate.AddDays(WeatherDataController.DAYS_BACK_FOR_TABLE);

            StationData stationData = _weatherRA.getReadingsFullStation(fromDate, tillDate, GlobalConst.PROTO_STATION_ID);
            TableStationData tsd = new TableStationData(fromDate, tillDate, stationData.WeatherReadingsRaw);

            return PartialView(MVC.WeatherData.Views._TdTablePartial, tsd);
        }


        // GET: WeatherData for Demo-Charts presentation
        public virtual ActionResult ChartData()
        {
            ViewBag.Message = "Wetterdaten hier.";

            DateTime tillDate = DateTime.Now;
            DateTime fromDate = tillDate.AddDays(WeatherDataController.DAYS_BACK_FOR_CHARTS);

            StationData stationData = _weatherRA.getReadingsFullStation(fromDate, tillDate, GlobalConst.PROTO_STATION_ID);
            TableStationData tsd = new TableStationData(fromDate, tillDate, stationData.WeatherReadingsRaw);

            return View(MVC.WeatherData.Views.ChartData, tsd);
        }
    }
}