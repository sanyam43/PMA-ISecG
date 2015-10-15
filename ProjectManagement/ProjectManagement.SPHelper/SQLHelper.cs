using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.SPHelper
{
    class SQLHelper
    {
        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
        public const string Param_Return = "@return";
        private static Hashtable conStrCache = Hashtable.Synchronized(new Hashtable());
        public static SqlParameter[] GetCachedParameters(string cacheKey)
        {
            SqlParameter[] cachedParms = (SqlParameter[])parmCache[cacheKey];

            if (cachedParms == null)
                return null;

            SqlParameter[] clonedParms = new SqlParameter[cachedParms.Length];

            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (SqlParameter)((ICloneable)cachedParms[i]).Clone();

            return clonedParms;
        }

        public static void CacheParameters(string cacheKey, params SqlParameter[] cmdParms)
        {
            parmCache[cacheKey] = cmdParms;
        }

        public static SqlDataReader ExecuteReader(string connString, CommandType cmdType, string cmdText, out int returnValue, params SqlParameter[] cmdParms)
        {
            connString = ConfigurationManager.ConnectionStrings["ProjectManagementConnectionString"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(connString);

            // we use a try/catch here because if the method throws an exception we want to 
            // close the connection throw code, because no datareader will exist, hence the 
            // commandBehaviour.CloseConnection will not work
            try
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                returnValue = Convert.ToInt32(cmd.Parameters[Param_Return].Value);
                //cmd.Parameters.Clear();
                return rdr;
            }
            catch(Exception ex)
            {
                conn.Close();
                throw;
            }
        }

        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {

            if (conn.State != ConnectionState.Open)
              conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
            //if (conn.State != ConnectionState.Open)
              //  conn.Open();
            if (trans != null)
                cmd.Transaction = trans;

        }
    }
}
