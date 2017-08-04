using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainKw.Stations
{
    public class Weather
    {
        public string ParticleEvent { get; set; }  // not used atm

        public System.DateTime PublishedAd { get; set; }
        
        public decimal Temperature { get; set; }
        public decimal Humidity { get; set; }
        public decimal PressureKPA { get; set; }
        public decimal RainMM { get; set; }
        public decimal WindKPH { get; set; }
        public decimal gustKPH { get; set; }
        public decimal windDirection { get; set; }
    }
}
