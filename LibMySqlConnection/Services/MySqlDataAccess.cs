using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace LibMySqlConnection.Services
{
    public class MySqlDataAccess
    {
        public List<T> LoadedData<T, U>(string sqlStatment, U parameters, string connectionString )
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sqlStatment,parameters).ToList();
                return rows;
            }
        }
        public void SaveData<T>(string sqlStatment, T parameters, string connectionString)
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Execute(sqlStatment, parameters);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteData<T, U>(string sqlStatment, U parameters, string connectionString)
        {
            try
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Execute(sqlStatment, parameters);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

