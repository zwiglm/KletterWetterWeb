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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="tillDate"></param>
        /// <param name="stationId"></param>
        /// <returns></returns>
        StationData getReadings(DateTime fromDate, DateTime tillDate, string stationId);
    }
}
