using Dataaccess.models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IEmployeeLogic
    {
        string GetNameService(string name);
        Task<IEnumerable<EmployeeModel>> GetDetailsService1();
        Task<IActionResult> GetDetailsService2foewithflag(string flag, string para1, string para2);
    }
}
