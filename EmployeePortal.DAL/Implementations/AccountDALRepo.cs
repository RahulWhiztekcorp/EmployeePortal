using Dapper;
using EmployeePortal.Common.Models;
using EmployeePortal.Common.Models.Account;
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
    public class AccountDALRepo : IAccountDALRepo
    {
        private string constring = "Server=WHIZTEK1\\SQLEXPRESS;Database=ATSDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
        private SqlConnection con;

        public AccountDALRepo()
        {
            con = new SqlConnection(constring);
        }













        private List<User> users = new List<User>
        {
        new User { Username = "user1", Password = "password1" },
        new User { Username = "user2", Password = "password2" }
        };

        public bool ValidateUserCredentials(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            return user != null;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var query = "SELECT * FROM Account_tbl";
            //var query = "SELECT * FROM " + typeof(User).Name;
            using (con)
            {
                var result = await con.QueryAsync<User>(query);
                return result.ToList();
            }
        }
        public async Task<bool> UserValidateUserCredentials(User user)
        {
            var data = await GetByUserNameAsync(user.Username, user.Password);
            return data != null;
        }
        public async Task<User> GetByUserNameAsync(string username, string password)
        {
            var query = "SELECT * FROM Account_tbl WHERE Username = @Username AND Password=@password";
            {
                var result = await con.QuerySingleOrDefaultAsync<User>(query, new { username, password });
                return result;
            }
        }
        public async Task<bool> Create(User _user)
        {
            var query = "INSERT INTO Account_tbl (Username,Email, Password,Role, CreatedDate,UpdatedDate) VALUES (@Username,@Email, @Password,@Role, @CreatedDate, @UpdatedDate)";
            var parameters = new DynamicParameters();
            parameters.Add("Username", _user.Username, DbType.String);
            parameters.Add("Password", _user.Password, DbType.String);
           
            using (con)
            {
                await con.ExecuteAsync(query, parameters);
                return true;
            }
            return false;
        }
    }
}

