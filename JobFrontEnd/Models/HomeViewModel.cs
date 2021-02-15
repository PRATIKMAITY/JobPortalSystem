using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobFrontEnd.Models
{
    public class HomeViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public List<JobViewModel> Jobs { get; set; }
    }
}