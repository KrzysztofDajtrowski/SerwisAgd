using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace SerwisAGD.Models
{
    public static class DapperORM
    {
        //private static string connectionString = @"Server=sql.freeasphost.net\MSSQL2016; Database = majorkupricz_serwisAGD; User Id = majorkupricz; Password = Ax231081990; Integrated Security = True;";
        public static string connectionString = @"Data Source=sql.freeasphost.net\MSSQL2016;" + "Initial Catalog=majorkupricz_serwisAGD;" +
  "User id=majorkupricz;" +
  "Password=Ax231081990;";
        /*funkcja pobiera nazwe procedury sql zapisanej na serwerze oraz DynamicParameter,
        Execute przekazuje do bazy danych nazwe procedury oraz parametry i wykonuje ta procedure */
        public static void ExecuteWithoutReturn(string ProcedureName, DynamicParameters param)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(ProcedureName, param, commandType: CommandType.StoredProcedure);
            }

        }
        public static void ConnectToDB()
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
            }
        }
        // DapperORM.ExecuteReturnScalar<int>(_,_);
        public static T ExecuteReturnScalar<T>(string ProcedureName, DynamicParameters param)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
              return (T)Convert.ChangeType(sqlCon.ExecuteScalar(ProcedureName, param, commandType: CommandType.StoredProcedure), typeof (T));
            }

        }
        //DapperORM.ReturnList<EmployeeModel> <= IEnumerable<EmployeeModel>
        public static IEnumerable<T> ReturnList<T>(string ProcedureName, DynamicParameters param)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(ProcedureName, param, commandType: CommandType.StoredProcedure);
            }

        }
    }
}