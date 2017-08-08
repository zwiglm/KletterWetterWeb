using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainKw.Stations
{
    public class Weather
    {

        protected Weather()
        {
        }

        public Weather(string pEvent, DateTime publishedAt, 
                       decimal temp, decimal hum, decimal press, decimal rain, decimal wind, decimal gust, decimal direction)
        {
            this.ParticleEvent = pEvent;
            this.PublishedAt = publishedAt;
            this.Temperature = (float)temp;
            this.Humidity = (float)hum;
            this.PressureKPA = (float)press;
            this.RainMM = (float)rain;
            this.WindKPH = (float)wind;
            this.GustKPH = (float)gust;
            this.WindDirection = (float)direction;
        }

        public string ParticleEvent { get; set; }  // not used atm

        public System.DateTime PublishedAt { get; set; }
        
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float PressureKPA { get; set; }
        public float RainMM { get; set; }
        public float WindKPH { get; set; }
        public float GustKPH { get; set; }
        public float WindDirection { get; set; }

    }
}
