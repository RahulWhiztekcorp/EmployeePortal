using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.DAL.DapperServices.Interfaces
{
    public interface IDapperSPServices<T>
    {
        Task CreateAsync(T entity);
        Task<T> ReadAsync(T entity);
        Task<IEnumerable<T>> ReadAllAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
