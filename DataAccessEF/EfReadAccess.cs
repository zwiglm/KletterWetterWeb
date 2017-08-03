using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppInterfaces.Base;

namespace DataAccessEF
{
    public abstract class EfReadAccess
    {
        protected IApplicationConfiguration _applicationConfiguration;
        protected Entities DBEntities { get; private set; }


        public EfReadAccess(IApplicationConfiguration applicationConfiguration)
        {
            this.DBEntities = new Entities(GetEntityFrameworkConnectionString(applicationConfiguration.MainSqlConnectionString));
            _applicationConfiguration = applicationConfiguration;
        }


        /// <summary>
        /// Creates a connection string for Entity Framework from an ordinary connection string.
        /// </summary>
        /// <param name="clientConnectionString"></param>
        /// <returns></returns>
        private static string GetEntityFrameworkConnectionString(string clientConnectionString)
        {
            EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.ProviderConnectionString = clientConnectionString;
            entityBuilder.Metadata = "res://*/KletterWetter.csdl|res://*/KletterWetter.ssdl|res://*/KletterWetter.msl";
            return entityBuilder.ToString();
        }

    }

    /// <summary>
    /// Expanded the EF Entities with a constructor for connectionstring
    /// </summary>
    public partial class Entities
    {
        public Entities(string connectionString) : base(connectionString) { }
    }
}
