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
    public class ProjectDal
    {
        public static ProjectInfo[] GetAllProjects()
        {
            ArrayList al = new ArrayList();

            int retValue = -1;


            //Generated Code for query : dbo.GetAllVendors
            using (SqlDataReader dr = ProjManagementAdmin.GetAllProjects(out retValue)) //Initialize and retrieve code for Datareader goes here
            {

                while (dr.Read())
                {
                    ProjectInfo project = new ProjectInfo();
                   
                    project.ProjectName = dr["project_name"].ToString();
                    project.ProjectCode = dr["project_code"].ToString();
                    project.CreatedDate = Convert.ToDateTime(dr["created_date"]);
                    project.ChangedDate = Convert.ToDateTime(dr["changed_date"]);
                    project.ChangedBy = dr["changed_by"].ToString();

                    al.Add(project);
                }
                //dr.Close();
            }

            ProjectInfo[] allInfo = new ProjectInfo[al.Count];
            al.CopyTo(allInfo);
            return allInfo;
        }

    }
}
