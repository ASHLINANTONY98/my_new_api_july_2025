using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dataaccess.context
{
    public class datacontext : DbContext
    {
        private readonly string _connectionString;
        /// </summary>
        private IConfiguration _Configuration;
        public datacontext(IConfiguration configuration)
        {
            _Configuration = configuration;
            _connectionString = _Configuration.GetConnectionString("OracleConnection");
        }

        public IDbConnection CreateConnection() => new OracleConnection(_connectionString);
    }
}
