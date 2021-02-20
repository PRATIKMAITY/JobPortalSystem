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
    public class CategoryController : Controller
    {
        private const string BaseUrl = "https://localhost:44359/api/";

        static HttpClient client = new HttpClient();
        // GET: Category
        public async Task<ActionResult> Index()
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


            var model = new HomeViewModel();

            // To get All Categories

            var streamTask = await client.GetAsync(BaseUrl + "Category/GetAllCategory");
            if (streamTask.IsSuccessStatusCode)
            {
                var response = streamTask.Content.ReadAsStringAsync().Result;
                model.Categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(response);
            }


            return View(model);
        }

        public async Task<ActionResult> details(string Categoryid)
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


            var model = new ListCategoryViewModel();

            // To get All Categories

            var streamTask = await client.GetAsync(BaseUrl + "Category/GetCategoryById?CId=" + Categoryid);
            if (streamTask.IsSuccessStatusCode)
            {
                var response = streamTask.Content.ReadAsStringAsync().Result;
                model.categories = JsonConvert.DeserializeObject<CategoryViewModel>(response);
            }
            //get job by category....................
            var streamTask1 = await client.GetAsync(BaseUrl + "Job/GetJobByCategoryId?CId=" + Categoryid);
            if (streamTask1.IsSuccessStatusCode)
            {
                var response = streamTask1.Content.ReadAsStringAsync().Result;
                model.Jobs   = JsonConvert.DeserializeObject<List<JobViewModel>>(response);
            }
            
            
            return View(model);


        }


    }
}