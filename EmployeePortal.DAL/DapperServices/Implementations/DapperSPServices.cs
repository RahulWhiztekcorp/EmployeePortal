using Dapper;
using EmployeePortal.Common.Models;
using EmployeePortal.DAL.DapperServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;


namespace EmployeePortal.DAL.DapperServices.Implementations
{
    public class DapperSPServices<T> : IDapperSPServices<T>
    {
        private string constring = "Server=WHIZTEK1\\SQLEXPRESS;Database=ATSDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
        private SqlConnection con;


        public DapperSPServices()
        {
            con = new SqlConnection(constring);
            con.Open();
        }
        //Create Method for Employee
        public async Task CreateAsync(T entity)
        {
            try
            {
                List<string> prop = new List<string>();
                foreach (var property in entity.GetType().GetProperties())
                {
                    prop.Add(property.Name);
                }
                var pro = "";
                for (int i = 0; i < prop.Count; i++)
                {
                    if (prop[i] == "Id")
                    {
                        pro += "";
                    }
                    else
                    {
                        pro += "@" + prop[i] + ",";
                    }
                }
                pro = pro.TrimEnd(',');
                var parameters = new DynamicParameters();
                foreach (var property in entity.GetType().GetProperties())
                {
                    parameters.Add("@" + property.Name, property.GetValue(entity));
                }
                var sql = InsertStoredProcedure(entity) + " " + pro;

                await con.ExecuteAsync(sql, parameters);
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> ReadAsync(T entity)
        {
            try
            {
                var sql = SelectByIdStoredProcedure(entity) + " @Id";
                var parameters = new DynamicParameters();
                foreach (var property in entity.GetType().GetProperties())
                {
                    parameters.Add("@" + property.Name, property.GetValue(entity));
                }
                var result = await con.QueryFirstOrDefaultAsync<T>(sql, parameters);
                con.Close();
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        //Get the Employee data from Employee Table
        public async Task<IEnumerable<T>> ReadAllAsync(T entity)
        {
            try
            {
                var sql = SelectStoredProcedure(entity);
                var result = await con.QueryAsync<T>(sql);
                con.Close();
                return result;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                List<string> prop = new List<string>();
                foreach (var property in entity.GetType().GetProperties())
                {
                    prop.Add(property.Name);
                }
                var pro = "";
                for (int i = 0; i < prop.Count; i++)
                {
                    if (prop[i] == "")
                    {
                        pro += "";
                    }
                    else
                    {
                        pro += "@" + prop[i] + ",";
                    }
                }
                pro = pro.TrimEnd(',');
                var parameters = new DynamicParameters();
                foreach (var property in entity.GetType().GetProperties())
                {
                    parameters.Add("@" + property.Name, property.GetValue(entity));
                }
                var sql = UpdateStoredProcedure(entity) + " " + pro;

                await con.ExecuteAsync(sql, parameters);
                con.Close() ;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task DeleteAsync(T entity)
        { 
             try
             {
                  var sql = DeleteStoredProcedure(entity) + " @Id";
                  var parameters = new DynamicParameters();
                  foreach (var property in entity.GetType().GetProperties())
                  {
                  parameters.Add("@" + property.Name, property.GetValue(entity));
                  }
                  await con.ExecuteAsync(sql, parameters);
                con.Close();
              }
              catch (Exception ex)
              {
                  throw ex;
              }
        }

                private string InsertStoredProcedure(T entity)
                {
                    return $"EXEC SP_Insert{entity.GetType().Name}";
                }

                private string SelectStoredProcedure(T entity)
                {
                    return $"EXEC SP_Select{entity.GetType().Name}";
                }

                private string UpdateStoredProcedure(T entity)
                {
                    return $"EXEC SP_Update{entity.GetType().Name}";
                }

                private string DeleteStoredProcedure(T entity)
                {
                    return $"EXEC SP_Delete{entity.GetType().Name}";
                }
                private string SelectByIdStoredProcedure(T entity)
                {
                    return $"EXEC SP_SelectEmployeeById{entity.GetType().Name}";
                }

    }

}

