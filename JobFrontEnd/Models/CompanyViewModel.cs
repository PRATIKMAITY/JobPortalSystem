using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobFrontEnd.Models
{
    public class CompanyViewModel
    {
        public Guid ComapanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyContactNo { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyDesc { get; set; }
        public string CompanyBranchAddr { get; set; }
        public List<JobViewModel> Jobs { get; set; }
    }
}