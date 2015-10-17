using ProjectManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManagement.BL;

namespace ProjectManagement.API
{
    public class SelectedProjectController : ApiController
    {
        public ProjectInfo Get(int id)
        {
            

            ProjectInfo project = new ProjectInfo();
            project = ProjectBl.GetProjectById(id);
            return project;
        }

        public HttpResponseMessage Post(ProjectInfo project)
        {
            
            return ProjectBl.UpdateProject(project);

        }

        public HttpResponseMessage Delete(int id,bool isOpen)
        {
            
            return ProjectBl.SoftDeleteProject(id,isOpen);

        }
    }
}
