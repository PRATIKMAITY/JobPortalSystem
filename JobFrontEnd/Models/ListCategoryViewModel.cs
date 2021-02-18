using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobFrontEnd.Models
{
    public class ListCategoryViewModel
    {
        public CategoryViewModel categories { get; set; }
        public List<JobViewModel> Jobs { get; set; }
    }
}