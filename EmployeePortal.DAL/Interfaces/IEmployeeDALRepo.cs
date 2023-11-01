using EmployeePortal.Common.Models;
using EmployeePortal.Common.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.DAL.Interfaces
{
    public interface IEmployeeDALRepo<T>
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();

        Task<Employee> GetEmployeeByidAsync(Employee _employee);
        Task Create(Employee _employee);
        Task Update(Employee _employee);
        Task Delete(Employee employee);

        //Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        //Task CreateAsync(Employee employee);
        //Task<Employee> ReadAsync(int id);
        //Task UpdateAsync(Employee employee);
        //Task DeleteAsync(int id);
    }
}
