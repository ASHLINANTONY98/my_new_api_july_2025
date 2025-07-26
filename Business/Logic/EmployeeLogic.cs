//using Dataaccess.Repository;
using Dataaccess.Interfaces;
using Dataaccess.models;
using Dataaccess.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;

namespace Business.Logic
{
    public class EmployeeLogic:ControllerBase, IEmployeeLogic
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeLogic(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public string GetNameService(string name)
        {
            string res = _employeeRepo.GetNameRepo(name);
            return res;
        }
        public async Task<IEnumerable<EmployeeModel>> GetDetailsService1()
        {
            return await _employeeRepo.GetDetailsRepo1();
        }
        public async Task<IActionResult> GetDetailsService2foewithflag(string flag, string para1, string para2)
        {
            var employeeDetails = await _employeeRepo.GetDetailswithflagrepo(flag, para1, para2);

            if (employeeDetails == null || !employeeDetails.Any())
            {
                return NotFound();
            }

            return Ok(employeeDetails);
        }

    }
}