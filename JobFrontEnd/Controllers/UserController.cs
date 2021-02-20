using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobFrontEnd.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            object loggedin;

            try
            {
                loggedin = Request.Cookies["LogInFlag"].Value;

            }
            catch (System.NullReferenceException ex)
            {
                // not logged in or null id.
                loggedin = "0";
            }
            if (loggedin.ToString() == "1")
            {
                ViewBag.loginflagmvc = 1;
            }
            return View();
        }
    }
}