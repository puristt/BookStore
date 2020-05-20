using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DatabaseManager
{
    public class DapperRepository<T> : IDapperRepository<T> where T : class
    {
        public string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["BookStore"].ConnectionString;
        }

        public IEnumerable<T> LoadData(string storedProcedure, object parameters)
        {
            string connectionString = GetConnectionString();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IEnumerable<T> rows = connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                return rows;
            }
        }

        public T FindById(object entityId)
        {
            string connectionString = GetConnectionString();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                T result = connection.Get<T>(entityId);

                return result;
            }
        }
        public IEnumerable<T2> LoadData<T2>(string storedProcedure, object parameters = null)
        {
            string connectionString = GetConnectionString();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                IEnumerable<T2> rows = connection.Query<T2>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                return rows;
            }
        }

        public int SaveData<T>(string storedProcedure, object parameters = null)
        {
            string connectionString = GetConnectionString();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var row = connection.Execute(storedProcedure,
                    parameters, commandType: CommandType.Text);

                return row;
            }
        }


        public int Count(string storedProcedure,object predicates = null)
        {
            string connectionString = GetConnectionString();

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                int count = (int)connection.ExecuteScalar(storedProcedure, predicates, null, null, CommandType.StoredProcedure);

                return count;
            }
        }
    }
}
