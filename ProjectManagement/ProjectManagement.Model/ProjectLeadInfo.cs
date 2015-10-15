using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Model
{
    public class ProjectLeadInfo
    {
        public string ProjectLeadId { get; set; }

        public string ProjectLeadName { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ChangedDate { get; set; }

        public string ChangedBy { get; set; }
    }

}
