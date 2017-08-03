using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppInterfaces.Base
{
    public interface IAppConfiguration
    {
        string MainSqlConnectionString { get; }
    }
}
