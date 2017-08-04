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
                tblWeather weather = queryResult.First<tblWeather>();
            }

            //var navigationItems = queryResult.Select(i => new NavItem(i.Comment, i.ID, i.Label, i.ChildID, (NavItemType)i.TypeID, i.StyleID, i.Term)
            //{
            //    ActivityLevel = i.Active,
            //});

            //return navigationItems;

            throw new NotImplementedException();
        }

    }
}
