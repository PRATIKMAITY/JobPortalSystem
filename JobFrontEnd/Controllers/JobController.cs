using JobFrontEnd.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JobFrontEnd.Controllers
{
    public class JobController : Controller
    {
        private const string BaseUrl = "https://localhost:44359/api/";

        static HttpClient client = new HttpClient();
        // GET: All Job
        public async Task<ActionResult> Index(int? page)
        {
<<<<<<< HEAD
            int pageNumber = (page ?? 1);
            int pagesize = 6;
=======
            
>>>>>>> 8a2235c567bd3e247cce572f0a9c3db2ac8dbe64
            string loggedin;
            try
            {

                loggedin = Request.Cookies["LogInFlag"].IfNotNull(arg => arg.Value);


            }
            catch (System.NullReferenceException)
            {
                // not logged in or null id.
                loggedin = "0";
            }

            if (loggedin == "1")
<<<<<<< HEAD

            {
                ViewBag.loginflagmvc = 1;
            }
            var model = new ListAllJobViewModel();
            var streamTask = await client.GetAsync(BaseUrl + "Job/GetAllJob");
            if (streamTask.IsSuccessStatusCode)
            {
                var response = streamTask.Content.ReadAsStringAsync().Result;
                var AllJobs = JsonConvert.DeserializeObject<List<JobViewModel>>(response);

                decimal count = (AllJobs.Count() / (Decimal)pagesize);
                decimal pages = Math.Ceiling(count);
                ViewBag.TPage = pages;
                int excluderecord = (pagesize * pageNumber) - pagesize;

                var finallist = AllJobs.Skip(excluderecord).Take(pagesize).ToList();
                model.AllJobs = finallist;
=======
            
                {
                    ViewBag.loginflagmvc = 1;
                }
                var model = new ListAllJobViewModel();
                var streamTask = await client.GetAsync(BaseUrl + "Job/GetAllJob");
                if (streamTask.IsSuccessStatusCode)
                {
                    var response = streamTask.Content.ReadAsStringAsync().Result;
                    model.AllJobs = JsonConvert.DeserializeObject<List<JobViewModel>>(response);
                  
                }
                return View(model);
>>>>>>> 8a2235c567bd3e247cce572f0a9c3db2ac8dbe64
            }
        
        public async Task<ActionResult> Details(string jobid)
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



            var model = new JobViewModel();
            var streamTask = await client.GetAsync(BaseUrl + "Job/GetJobByJobId?JId="+jobid);
            if (streamTask.IsSuccessStatusCode)
            {
                var response = streamTask.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<JobViewModel>(response);
            }


            return View(model);
        }
        public async Task<ActionResult> Details1(string jobloc)
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


            var model = new JobViewModel();
            var streamTask = await client.GetAsync(BaseUrl + "Job/GetJobByLocation?loc=" + jobloc);
            if (streamTask.IsSuccessStatusCode)
            {
                var response = streamTask.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<JobViewModel>(response);
            }


            return View(model);
        }

    }
}