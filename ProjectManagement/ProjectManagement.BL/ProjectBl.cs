using ProjectManagement.DAL;
using ProjectManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
