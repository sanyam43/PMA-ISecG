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

                    project.ProjectId = Convert.ToInt32(dr["project_id"]);
                    project.ProjectName = dr["project_name"].ToString();
                    project.ProjectCode = dr["project_code"].ToString();
                    project.ProjectLead = dr["project_lead_name"].ToString();
                    project.IsActive = Convert.ToBoolean(dr["is_active"]);
                    project.CreatedDate = Convert.ToDateTime(dr["created_date"]);
                    project.ChangedDate = Convert.ToDateTime(dr["changed_date"]);
                    project.ChangedBy = dr["changed_by"].ToString();
                    if(project.IsActive == true)
                    {
                        project.OpenClose = "Close";
                    }
                    else
                    {
                        project.OpenClose = "Open";
                    }

                    al.Add(project);
                }
                //dr.Close();
            }

            ProjectInfo[] allInfo = new ProjectInfo[al.Count];
            al.CopyTo(allInfo);
            return allInfo;
        }

        public static ProjectInfo GetProjectById(int projectId)
        {
            int retValue = -1;
            ProjectInfo project = new ProjectInfo();
            //Generated Code for query : dbo.GetAllVendors
            using (SqlDataReader dr = ProjManagementAdmin.GetProjectById(projectId, out retValue)) //Initialize and retrieve code for Datareader goes here
            {
                while (dr.Read())
                {

                    project.ProjectId = Convert.ToInt32(dr["project_id"]);
                    project.ProjectName = dr["project_name"].ToString();
                    project.ProjectCode = dr["project_code"].ToString();
                    project.ProjectLead = dr["project_lead_name"].ToString();
                    project.IsActive = Convert.ToBoolean(dr["is_active"]);
                    project.CreatedDate = Convert.ToDateTime(dr["created_date"]);
                    project.ChangedDate = Convert.ToDateTime(dr["changed_date"]);
                    project.ChangedBy = dr["changed_by"].ToString();

                }
                //dr.Close();
            }

            return project;
        }

        public static int SoftDeleteProject(int projectId,bool isOpen)
        {
            int retValue = -1;
            return ProjManagementAdmin.SoftDeleteProject(projectId,isOpen, out retValue);
        }

        public static int UpdateProject(ProjectInfo project)
        {
            int retValue = -1;
            return ProjManagementAdmin.UpdateProject(project, out retValue);
        }

        public static int AddNewProject(ProjectInfo project)
        {
            if (project == null)
                throw new ArgumentNullException("project");


            int retValue = -1;
            return ProjManagementAdmin.AddNewProject(project, out retValue);
        }



    }
}
