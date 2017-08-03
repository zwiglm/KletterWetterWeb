using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using AppInterfaces.Base;

namespace KletterWetter.Configuration
{
    public class WebConfiguration : IApplicationConfiguration
    {
        public string MainSqlConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["mainDb"].ConnectionString; }
        }
    }
}