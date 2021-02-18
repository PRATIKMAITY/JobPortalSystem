﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobFrontEnd.Models
{
	public class JobViewModel
	{
        public Guid JobId { get; set; }
        public string JobName { get; set; }
        public Guid ComapanyId { get; set; }
        public string JobType { get; set; }
        public string ExpextedSalary { get; set; }
        public string JobLoc { get; set; }
        public string JobDesc1 { get; set; }
        public int CategoryId { get; set; }
        public string JobPos { get; set; }
        public string MinQulafication { get; set; }
        public string JobSkill { get; set; }

        public virtual CompanyViewModel company { get; set; }

        public virtual CategoryViewModel JobCategory { get; set; }


    }
}