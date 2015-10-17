using ProjectManagement.BL;
using ProjectManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace ProjectManagement.API
{
    public class ProjectController : ApiController
    {
        public JsonResult<IEnumerable<ProjectInfo>> Get()
        {

            ProjectInfo[] ListOfProjects = ProjectBl.GetAllProjects();

            var proj = from c in ListOfProjects
                       select c;


            return Json(proj);

        }

        public HttpResponseMessage Post(ProjectInfo project)
        {
           
            try
            {
                
                ProjectBl.AddNewProject(project);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }


        }
    }
}
