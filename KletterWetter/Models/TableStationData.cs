using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainKw.Stations;

namespace KletterWetter.Models
{
    public class TableStationData
    {
        public IEnumerable<Weather> WeatherRows { get; set; }
    }
}