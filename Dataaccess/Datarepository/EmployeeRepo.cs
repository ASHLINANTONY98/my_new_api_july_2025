using Dataaccess.context;
using Dapper.Oracle;
using Dapper;
using Oracle.ManagedDataAccess.Types;
using System.Data;
using Dataaccess.models;
using Microsoft.AspNetCore.Mvc;
using Dataaccess.Interfaces; //Add this

namespace Dataaccess.Repository
{
    //public class EmployeeRepo:ControllerBase
    public class EmployeeRepo : IEmployeeRepo
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
        //executoion without flag
        public async Task<IEnumerable<EmployeeModel>> GetDetailsRepo1()
        {
            OracleRefCursor result = null;
            var procedureName = "proc_viewemp_420681";

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

        //executoion with flag
        public async Task<IEnumerable<EmployeeModel>> GetDetailswithflagrepo(string flag, string para1, string para2)
        {
            OracleRefCursor result = null;
            var procedureName = "proc_viewempwithflag_420681";
            var parameters = new OracleDynamicParameters();
            //input
            parameters.Add("flag", flag, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue1", para1, OracleMappingType.NVarchar2, ParameterDirection.Input);
            parameters.Add("paravalue2", para2, OracleMappingType.NVarchar2, ParameterDirection.Input);

            //output
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