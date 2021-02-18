using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Job_Portal_api.Model
{
    public class ApplyJobModel
    {
        public Guid ApplyId { get; set; }
        public Nullable<System.Guid> JobId { get; set; }
        public Nullable<System.Guid> UserId { get; set; }
        public Nullable<System.DateTime> ApplyDate { get; set; }

        public virtual JobViewModel JobDesc { get; set; }
        public virtual UserViewModel User { get; set; }
    }
}