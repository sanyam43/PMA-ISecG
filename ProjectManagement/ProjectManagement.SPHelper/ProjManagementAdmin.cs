using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.SPHelper
{
    public class ProjManagementAdmin
    {
        private static readonly string PROJMGMT_CONN_STRING;

        #region Stored Procedure Constants
        private const string PROC_GETALLPROJECTS = "dbo.GetAllProjects";

        #endregion

        #region SqlParameter Constants
        private const string PARAM_RETURN = "@return";

        private const string PARAM__CHANGEDBY = "@changed_by";
        private const string PARAM_PROJECT_CREATEDDATE = "@changed_by";
        private const string PARAM_PROJECT_CHANGEDDATE = "@changed_date";

        private const string PARAM_PROJECT_NAME = "@project_name";
        private const string PARAM_PROJECT_CODE= "@project_code";
        private const string PARAM_PROJECT_LEAD_NAME = "@project_lead";


        public static SqlDataReader GetAllProjects(out int retValue)
        {
            retValue = -1;
            SqlDataReader dr = null;
            SqlParameter[] parms = GetGetAllProjectsParams();
            dr = ExecuteReader(PROC_GETALLPROJECTS, parms, out retValue);

            return dr;
        }

        private static SqlParameter[] GetGetAllProjectsParams()
        {
            SqlParameter[] sqlParms = SQLHelper.GetCachedParameters(PROC_GETALLPROJECTS);
            if (sqlParms == null)
            {
                sqlParms = new SqlParameter[]
                            {
                                new SqlParameter(PARAM_RETURN, SqlDbType.Int)
                               
                            };

                sqlParms[0].Direction = ParameterDirection.ReturnValue;
                SQLHelper.CacheParameters(PROC_GETALLPROJECTS, sqlParms);
            }

            //Assigning values to parameter
            sqlParms[0].Value = -1;
            return sqlParms;
        }
        #endregion

        static ProjManagementAdmin()
        {
            PROJMGMT_CONN_STRING = ConfigurationManager.ConnectionStrings["ProjectManagementConnectionString"].ConnectionString;
        }

        #region SQL Methods

        private static void ThrowIfNullParams(string spName, SqlParameter[] parms)
        {
            if (parms == null)
                throw new ArgumentException("Couldn't build the parameters for procedure:" + spName);
        }
        private static SqlDataReader ExecuteReader(string spName, SqlParameter[] parms, out int retValue)
        {
            ThrowIfNullParams(spName, parms);
            retValue = -1;
            return SQLHelper.ExecuteReader(PROJMGMT_CONN_STRING, CommandType.StoredProcedure, spName, out retValue, parms);
        }

        #endregion

    }
}
