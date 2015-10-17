using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Model
{
    public class ProjectInfo
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string ProjectCode { get; set;  }
    
        public string ProjectLead { get; set; }

        public string ProjectLeadId { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ChangedDate { get; set; }

        public string ChangedBy { get; set; }

        public string OpenClose { get; set; }
    }
}
