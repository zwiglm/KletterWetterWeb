using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainKw.Stations
{
    public class Weather
    {
        public Weather(string pEvent, DateTime publishedAt, 
                       decimal temp, decimal hum, decimal press, decimal rain, decimal wind, decimal gust, decimal direction)
        {
            this.ParticleEvent = pEvent;
            this.PublishedAt = publishedAt;
            this.Temperature = temp;
            this.Humidity = hum;
            this.PressureKPA = press;
            this.RainMM = rain;
            this.WindKPH = wind;
            this.GustKPH = gust;
            this.WindDirection = direction;
        }

        public string ParticleEvent { get; set; }  // not used atm

        public System.DateTime PublishedAt { get; set; }
        
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
        public decimal PressureKPA { get; set; }
        public decimal RainMM { get; set; }
        public decimal WindKPH { get; set; }
        public decimal GustKPH { get; set; }
        public decimal WindDirection { get; set; }
    }
}
