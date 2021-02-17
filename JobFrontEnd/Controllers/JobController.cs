using JobFrontEnd.Models;
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
        public async Task<ActionResult> Index()
        {
            var model = new ListAllJobViewModel();
            var streamTask = await client.GetAsync(BaseUrl + "Job/GetAllJob");
            if (streamTask.IsSuccessStatusCode)
            {
                var response = streamTask.Content.ReadAsStringAsync().Result;
                model.AllJobs = JsonConvert.DeserializeObject<List<JobViewModel>>(response);
            }
            return View(model);
        }
        public async Task<ActionResult> Details(string jobid)
        {
            var model = new JobViewModel();
            var streamTask = await client.GetAsync(BaseUrl + "Job/GetJobByJobId?JId="+jobid);
            if (streamTask.IsSuccessStatusCode)
            {
                var response = streamTask.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<JobViewModel>(response);
            }


            return View(model);
        }
    }
}