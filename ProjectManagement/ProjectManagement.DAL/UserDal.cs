using ProjectManagement.Model;
using ProjectManagement.SPHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.DAL
{
    public class UserDal
    {
        public static UserInfo[] GetAllUsers()
        {
            ArrayList al = new ArrayList();

            int retValue = -1;


            //Generated Code for query : dbo.GetAllVendors
            using (SqlDataReader dr = ProjManagementAdmin.GetAllUsers(out retValue)) //Initialize and retrieve code for Datareader goes here
            {

                while (dr.Read())
                {
                    UserInfo user = new UserInfo();

                    user.UserName = dr["user_name"].ToString();
                    user.UserId = Convert.ToInt32(dr["user_id"]);
                    user.UserEmail = dr["user_email"].ToString();
                    user.RoleId = Convert.ToInt32(dr["role_id"]);
                   // user.Password = Convert.ToChar(dr["password"]);
                    user.CreatedDate = Convert.ToDateTime(dr["created_date"]);
                    user.ChangedDate = Convert.ToDateTime(dr["changed_date"]);
                    user.ChangedBy = dr["changed_by"].ToString();

                    al.Add(user);
                }
                //dr.Close();
            }

            UserInfo[] allInfo = new UserInfo[al.Count];
            al.CopyTo(allInfo);
            return allInfo;

        }
    }
}
