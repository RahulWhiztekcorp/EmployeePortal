using EmployeePortal.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.BAL.Interfaces
{
    public interface IEmployeeBALRepo
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

       Task<Employee> GetEmployeeByidAsync(Employee _employee);
        Task<bool> Create(Employee _employee);
        Task<bool> Update(Employee _employee);
        Task<bool> Delete(Employee employee);
    }
}
