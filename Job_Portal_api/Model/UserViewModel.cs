﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_Portal_api.Model
{
    public class UserViewModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserContactNo { get; set; }
        public string UserEmail { get; set; }
        public string Addr { get; set; }
        public string DOB { get; set; }
        public string C10thBoard { get; set; }
        public Nullable<decimal> C10thPercentage { get; set; }
        public string HSBoard { get; set; }
        public Nullable<decimal> HSPercentage { get; set; }
        public string UGUnivercity { get; set; }
        public string UGCollege { get; set; }
        public Nullable<decimal> UGPercentage { get; set; }
        public string PGUniversity { get; set; }
        public string PGCollege { get; set; }
        public Nullable<decimal> PGPercentage { get; set; }
        public string Skill1 { get; set; }
        public string Skill2 { get; set; }
        public string Skill3 { get; set; }
        public string CurrentOfcName { get; set; }
        public string CurrentDesignation { get; set; }
        public string CurrentySalary { get; set; }
        public string TotalYearOfExp { get; set; }
        public string CurrentLoc { get; set; }
        public string Gender { get; set; }
        public string CvPath { get; set; }
        public string AlternatePhno { get; set; }
        public Nullable<System.DateTime> Joinedon { get; set; }
        public string aspnetuserid { get; set; }
        public Nullable<int> C10thpassoutyear { get; set; }
        public Nullable<int> C12thpassoutyear { get; set; }
        public Nullable<int> UGPassoutYear { get; set; }
        public Nullable<int> PGPassoutYear { get; set; }
        public string C10thSchoolName { get; set; }
        public string C12thSchoolName { get; set; }
        public string ProfilePicPath { get; set; }



    }
}