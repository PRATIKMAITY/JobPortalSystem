using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_Portal_api.Model
{
    public class CategoryViewModel
    {
        public string CategoryName { get; set; }
        public string CategoryDesc { get; set; }
        public int CategoryId { get; set; }
        public string CategoryIcon { get; set; }
    }
}