using EmployeePortal.BAL.Interfaces;
using EmployeePortal.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBALRepo _employeeBALRepo;
       public EmployeeController(IEmployeeBALRepo _empBALRepo)
        {
            _employeeBALRepo = _empBALRepo;
        }
        [HttpGet("GetAllEmployeesAsync")]
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeBALRepo.GetAllEmployeesAsync();
        }
        [HttpPost("GetEmployeeByidAsync")]                                             
        public async Task<Employee> GetEmployeeByidAsync(Employee _employee)
        {
            return await _employeeBALRepo.GetEmployeeByidAsync(_employee);
        }
        [HttpPost("Create")]
        public async Task<bool> Create(Employee _employee)
        {
            return await _employeeBALRepo.Create(_employee);

        }
        [HttpPut("Update")]
        public async Task<bool> Update(Employee _employee)
        {
            return await _employeeBALRepo.Update(_employee);

        }
        [HttpDelete("Delete")]
        public async Task<bool> Delete(Employee employee)
        {
            return await _employeeBALRepo.Delete(employee);

        }
    }
}
