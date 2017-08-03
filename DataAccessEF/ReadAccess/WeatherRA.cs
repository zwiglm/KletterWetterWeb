using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppInterfaces.Base;
using AppInterfaces.ReadAccess;

namespace DataAccessEF.ReadAccess
{
    public class WeatherRA : EfReadAccess, IWeatherRA
    {
        public WeatherRA(IApplicationConfiguration applicationConfiguration) :
            base(applicationConfiguration)
        {

        }
    }
}
