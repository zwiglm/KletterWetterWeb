using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainKw.Stations
{
    public class WeatherRaw : Weather
    {
        public WeatherRaw(string pEvent, DateTime publishedAt, 
                          decimal temp, decimal hum, decimal press, decimal rain, decimal wind, decimal gust, decimal direction,
                          decimal powerStat)
            : base(pEvent, publishedAt, 
                       temp, hum, press, rain, wind, gust, direction)
        {
            this.PowerStatus = powerStat;
        }

        public decimal PowerStatus { get; set; }
    }
}
