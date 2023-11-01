using Dapper;
using EmployeePortal.Common.Models;
using EmployeePortal.Common.Models.Account;
using EmployeePortal.DAL.DapperServices.Implementations;
using EmployeePortal.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.DAL.Implementations
{
    public class EmployeeDALRepo
    {
        private string constring = "Server=WHIZTEK1\\SQLEXPRESS;Database=ATSDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
        private SqlConnection con;
        DapperSPServices<Employee> employeeRepository = new DapperSPServices<Employee>();

        public EmployeeDALRepo()
        {
            con = new SqlConnection(constring);
        }

       
        public async  Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            try
            {
                var result = await employeeRepository.ReadAllAsync(new Employee());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        public async Task<Employee> GetEmployeeByidAsync(Employee _employee)
        {
            try
            {
                return await employeeRepository.ReadAsync(_employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        } 
        public async Task<bool> Create(Employee _employee)
        {
            //var query = "INSERT INTO Employee_tbl  (FirstName,LastName,Email,Age,AdharNo,PhoneNumber,Address,Salary,D_Id) VALUES (@FirstName,@LastName,@Email, @Age,@AdharNo, @PhoneNumber, @Address,@Salary,@D_Id)";
            //var parameters = new DynamicParameters();
            //parameters.Add("FirstName", _employee.FirstName, DbType.String);
            //parameters.Add("LastName",_employee.LastName,DbType.String);
            //parameters.Add("Email", _employee.Email, DbType.String);
            //parameters.Add("Age", _employee.Age, DbType.Int32);
            //parameters.Add("AdharNo", _employee.AdharNo, DbType.Int64);
            //parameters.Add("PhoneNumber", _employee.PhoneNumber, DbType.Int64);
            //parameters.Add("Address", _employee.Address, DbType.String);
            //parameters.Add("Salary", _employee.Salary,DbType.Decimal);
            //parameters.Add("D_Id", _employee.D_Id, DbType.Int32);
            //using (con)
            //{
            //    await con.ExecuteAsync(query, parameters);

            //    return true;
            //}
            //return false;
            try
            {

                if (_employee != null)
                {
                    await employeeRepository.CreateAsync(_employee);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Update(Employee _employee)
        {
            try
            {
                if (_employee != null)
                {
                    await employeeRepository.UpdateAsync(_employee);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> Delete(Employee employee)
        {
            try
            {
                if (employee != null)
                {
                    await employeeRepository.DeleteAsync(employee);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
