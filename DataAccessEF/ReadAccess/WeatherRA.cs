using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppInterfaces.Base;
using AppInterfaces.ReadAccess;
using DomainKw.Stations;

namespace DataAccessEF.ReadAccess
{
    public class WeatherRA : EfReadAccess, IWeatherRA
    {
        public WeatherRA(IApplicationConfiguration applicationConfiguration) :
            base(applicationConfiguration)
        {

        }


        public StationData getReadings(DateTime fromDate, DateTime tillDate, string stationId)
        {
            var query = DBEntities.tblWeather.
                            Where(w => w.coreid == stationId && (w.publishedAt >= fromDate && w.publishedAt <= tillDate)).
                            Select(w => w);

            var queryResult = query.ToList();

            StationData result = new StationData();
            if (queryResult.Count > 0)
            {
                tblWeather firstEntry = queryResult.First<tblWeather>();

                result.StationId = firstEntry.coreid;
                result.ParticleUser = firstEntry.prtclUserid;

                result.WeatherReadingsRaw = 
                    queryResult.Select(y =>
                        new WeatherRaw(
                            y.@event, y.publishedAt, y.temperature, y.humidity, y.pressure, y.rainMM, y.windKPH, y.gustKPH, y.windDirection, y.powerStatus))
                .ToList();

                result.WeatherReadings = 
                    queryResult.Select(y => 
                        new Weather(y.@event, y.publishedAt, y.temperature, y.humidity, y.pressure, y.rainMM, y.windKPH, y.gustKPH, y.windDirection))
                        .ToList();

                result.ContinuosMetaData = 
                    queryResult.Select(z => new ContinuosMeta() { PublishedAd = z.publishedAt, ParticleFirmware = z.prtclFwVersion, PowerStatus = z.powerStatus }).ToList();
            }

            return result;
        }


        #region Private

        #endregion

    }
}
