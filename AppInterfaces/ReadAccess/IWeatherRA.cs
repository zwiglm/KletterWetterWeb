using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainKw.Stations;

namespace AppInterfaces.ReadAccess
{
    public interface IWeatherRA
    {
        StationData getReadings(DateTime from, DateTime till, string stationId);
    }
}
