using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dataaccess.models;

namespace Dataaccess.Interfaces
{
    public interface IEmployeeRepo
    {
        string GetNameRepo(string name);
        Task<IEnumerable<EmployeeModel>> GetDetailsRepo1();
        Task<IEnumerable<EmployeeModel>> GetDetailswithflagrepo(string flag, string para1, string para2);
    }
}
