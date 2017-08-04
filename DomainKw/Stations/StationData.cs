using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainKw.Stations
{
    public class StationData
    {
        public IEnumerable<Weather> WeatherReadings { get; set; }

        public string StationId { get; set; }
        public string ParticleUser { get; set; }  // not used atm

        public IEnumerable<ContinuosMeta> ContinuosMetaData { get; set; }
    }
}
