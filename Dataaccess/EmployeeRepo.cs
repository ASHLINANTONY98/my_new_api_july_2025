using Dataaccess.context;
using Dapper.Oracle;
using Dapper;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using Dataaccess.models;

namespace Dataaccess.Datarepository
{
    public class EmployeeRepo
    {
        private readonly datacontext _context;
        public EmployeeRepo(datacontext context)
        {

            _context = context;
        }

        public string GetNameRepo(string name)
        {
            string res = "my name is " + name;
            return res;
        }

        public async Task<IEnumerable<EmployeeModel>> GetDetailsRepo1()
        {
            OracleRefCursor result = null;
            var procedureName = "proc_viewemp";

            var parameters = new OracleDynamicParameters();
            parameters.Add("emp_refcur", result, OracleMappingType.RefCursor, ParameterDirection.Output);
            parameters.BindByName = true;

            using var connection = _context.CreateConnection();

            var response = await connection.QueryAsync<EmployeeModel>(
                procedureName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return response;
        }

    }




}