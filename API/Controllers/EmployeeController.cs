using Business.Interfaces;
using Business.Logic;
using Dataaccess.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authorization;


namespace API.Controllers
{
    [Tags("Employee Management")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //private readonly EmployeeLogic _employeeLogic;
        private readonly IEmployeeLogic _employeeLogic;
        public EmployeeController(IEmployeeLogic employeeLogic)
        {

            _employeeLogic = employeeLogic;
        }

        /// <summary>
        /// Gets a greeting or message based on the employee name.
        /// </summary>
        /// <param name="name">Employee name passed via URL.</param>
        /// <returns>A string message.</returns>
        [Authorize]
        [HttpGet("Getname/{name}")]
        public string Getname([FromRoute] string name)
        {
            string res = _employeeLogic.GetNameService(name);
            return res;
        }

        /// <summary>
        /// Retrieves all employee records from the database.
        /// </summary>
        /// <returns>A list of EmployeeModel entries.</returns>
        [Authorize]
        [HttpGet("GetDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetDetails()
        {
            var result = await _employeeLogic.GetDetailsService1();
            return Ok(result);
        }

        /// <summary>
        /// Fetches filtered employee details using a flag and parameters.
        /// </summary>
        /// <param name="flag">Filter flag value.</param>
        /// <param name="para1">Extra parameter 1.</param>
        /// <param name="para2">Extra parameter 2.</param>
        /// <returns>Filtered data based on input parameters.</returns>
        [Authorize]
        [HttpGet("GetDetails2/{flag}/{para1}/{para2}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> getdetails2(
        [FromRoute] string flag,
        [FromRoute] string para1,
        [FromRoute] string para2)

        {
            var result = await _employeeLogic.GetDetailsService2foewithflag(flag, para1, para2);
            return Ok(result);
        }
    }
}
