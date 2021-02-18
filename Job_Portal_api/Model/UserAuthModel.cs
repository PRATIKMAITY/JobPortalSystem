using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Job_Portal_api.Model
{

    public class UserAuthModel
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string rolename { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}