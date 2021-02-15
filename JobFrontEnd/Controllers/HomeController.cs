using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JobFrontEnd.Models;
using Newtonsoft.Json;

namespace JobFrontEnd.Controllers
{
    public class HomeController : Controller
    {
        
        private const string BaseUrl = "https://localhost:44359/api/";
        
        static HttpClient client = new HttpClient();
        public async Task<ActionResult> Index()
        {        
            var model = new HomeViewModel();
         
            // To get All Categories
            
            var streamTask = await client.GetAsync(BaseUrl + "Category/GetAllCategory");
            if (streamTask.IsSuccessStatusCode)
            {
                var response = streamTask.Content.ReadAsStringAsync().Result;
                model.Categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(response);
            }

            var streamTask1 = await client.GetAsync(BaseUrl + "Job/GetAllJob");
            if (streamTask1.IsSuccessStatusCode)
            {
                var response = streamTask1.Content.ReadAsStringAsync().Result;
                model.Jobs = JsonConvert.DeserializeObject<List<JobViewModel>>(response);
            }

            return View(model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}