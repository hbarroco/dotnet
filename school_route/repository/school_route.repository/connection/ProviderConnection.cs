using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace school_route.repository.connection
{
    public class ProviderConnection
    {
        private readonly IConfiguration _configuration;

        public ProviderConnection(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public IDbConnection GetSchoolRouteConnection
        {
            get
            {
                var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                return connection;
            }
        }
    }
}