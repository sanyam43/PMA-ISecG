using ProjectManagement.DAL;
using ProjectManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.BL
{
    public class ProjectBl
    {
        public static ProjectInfo[] GetAllProjects()
        {
            ProjectInfo[] projectInfo = ProjectDal.GetAllProjects();
            return projectInfo;

        }

        public static int AddNewProject(ProjectInfo project)
        {
            return ProjectDal.AddNewProject(project);
        }



        public static ProjectInfo GetProjectById(int projectId)
        {
            return ProjectDal.GetProjectById(projectId);
        }



        public static HttpResponseMessage SoftDeleteProject(int projectId,bool isOpen)
        {
            try
            {
                int val = ProjectDal.SoftDeleteProject(projectId,isOpen);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION: " + ex);
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

        }

        public static HttpResponseMessage UpdateProject(ProjectInfo project)
        {
            try
            {
                int val = ProjectDal.UpdateProject(project);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION: " + ex);
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

        }
    }
}
