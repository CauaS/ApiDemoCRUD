using ApiDemoCRUD.EmployeeData;
using ApiDemoCRUD.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDemoCRUD.Controllers
{
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)  
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        [Route("/getAllEmployees")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpPost]
        [Route("/updateEmployee/{id}")]
        public IActionResult UpdateEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);

            if (employee != null) return Ok(employee);
                        
            return NotFound("Employee Does Not Exist");
        }

        [HttpPost]
        [Route("/addEmployee")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
        }

        [HttpDelete]
        [Route("/deleteEmployee/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);

            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
            } 
           
            return NotFound("Não existe!");
        }

    }
}
