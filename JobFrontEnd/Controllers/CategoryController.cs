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
            var model = new ListCategoryViewModel();

            // To get All Categories

            var streamTask = await client.GetAsync(BaseUrl + "Category/GetCategoryById?CId=" + Categoryid);
            if (streamTask.IsSuccessStatusCode)
            {
                var response = streamTask.Content.ReadAsStringAsync().Result;
                model.categories = JsonConvert.DeserializeObject<CategoryViewModel>(response);
            }

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