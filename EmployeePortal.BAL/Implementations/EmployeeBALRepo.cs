using EmployeePortal.BAL.Interfaces;
using EmployeePortal.Common.Models;
using EmployeePortal.DAL.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.BAL.Implementations
{
    public class EmployeeBALRepo: IEmployeeBALRepo
    {
      public  EmployeeDALRepo empdalrepo=new EmployeeDALRepo();
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await empdalrepo.GetAllEmployeesAsync();
        }

       public async Task<Employee> GetEmployeeByidAsync(Employee _employee)
        {
            return await empdalrepo.GetEmployeeByidAsync(_employee);
        }
       public async  Task<bool> Create(Employee _employee)
        {
            return await empdalrepo.Create(_employee);

        }
        public async  Task<bool> Update(Employee _employee)
        {
            return await empdalrepo.Update(_employee);

        }
        public async Task<bool> Delete(Employee employee)
        {
            return await empdalrepo.Delete(employee);

        }
        

    }
}
