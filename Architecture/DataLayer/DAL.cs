using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace DataLayer
{
    public class DAL
    {
        #region DataMembers
        SqlCommand cmd;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="commandName">Command name, sp name</param>
        /// <param name="commandType">stored procedure Name, Direct Text</param>
        public DAL(string commandName, System.Data.CommandType commandType =  System.Data.CommandType.StoredProcedure){
            cmd = new SqlCommand(commandName);
            cmd.CommandType = commandType;
        }
        #endregion
        // For creating transaction
        public static  SqlConnection getNewConnection()
        {
            string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["connectionString"];
            return new SqlConnection(ConnectionString);
        }
        public void AddParameter(string ParamterName, System.Data.SqlDbType sqlDbType, Object Value){
            cmd.Parameters.Add(ParamterName, Value);
        }
        public DataSet Execute(SqlConnection sqlConnection = null)
        {
            try
            {
                if (sqlConnection == null)
                {
                    sqlConnection = getNewConnection();
                }
                if (sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();
                cmd.Connection = sqlConnection;
                SqlDataAdapter adp = new SqlDataAdapter();
                DataSet ds = new DataSet();
                adp.SelectCommand = cmd;
                adp.Fill(ds);
                sqlConnection.Close();
                return ds;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                    sqlConnection.Close();
            }
            
        }

    }
}
