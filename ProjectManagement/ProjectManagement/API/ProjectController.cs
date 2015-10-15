using ProjectManagement.BL;
using ProjectManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManagement.API
{
    public class ProjectController : ApiController
    {
        public IEnumerable<ProjectInfo> Get()
        {

            ProjectInfo[] ListOfProjects = ProjectBl.GetAllProjects();

            var proj = from c in ListOfProjects
                       select c;


            return proj.ToList();

        }
    }
}
