using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainKw.Stations
{
    public class WeatherRaw : Weather
    {

        private WeatherRaw()
        {
            ParticleEvent = String.Empty;
            PublishedAt = DateTime.MinValue;
            Temperature = float.NaN;
            Humidity = float.NaN;
            RainMM = float.NaN;
            WindKPH = float.NaN;
            GustKPH = float.NaN;
            WindDirection = float.NaN;
            PowerStatus = float.NaN;
        }

        public WeatherRaw(string pEvent, DateTime publishedAt, 
                          decimal temp, decimal hum, decimal press, decimal rain, decimal wind, decimal gust, decimal direction,
                          decimal powerStat)
            : base(pEvent, publishedAt, 
                       temp, hum, press, rain, wind, gust, direction)
        {
            this.PowerStatus = (float)powerStat;
        }

        public static WeatherRaw Empty { get { return new WeatherRaw(); } }
        public float PowerStatus { get; set; }

    }
}
