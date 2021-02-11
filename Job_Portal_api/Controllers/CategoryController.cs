using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Job_Portal_api.Data;
using Job_Portal_api.Model;
using System.Web.Http.ModelBinding;
using System.Threading.Tasks;
using AutoMapper;

namespace Job_Portal_api.Controllers
{
    public class CategoryController : ApiController
    {
        private jobpotaldbEntities _db = new jobpotaldbEntities();


        [HttpGet]
        [ActionName("GetAllCategory")]
        public async Task<IEnumerable<CategoryViewModel>> GetAllCategory()
        {
            var query = await _db.JobCategories.ToListAsync();

            var model = new List<CategoryViewModel>();
            foreach (var item in query)
            {
                model.Add(new CategoryViewModel
                {
                    CategoryDesc = item.CategoryDesc,
                    CategoryIcon = item.CategoryIcon,
                    CategoryId = item.CategoryId,
                    CategoryName = item.CategoryName,

                });
            }


            return model;
        }

        // get category by id..............................
        [HttpGet]
        [ActionName("GetCategoryById")]
        public async Task<CategoryViewModel> GetCategoryById (string CId)
        {

            var query = await _db.JobCategories.Where(a => a.CategoryId.ToString() == CId).SingleOrDefaultAsync();
            var model = new CategoryViewModel();
            if (query != null)
            {

                model = new CategoryViewModel
                {
                    CategoryId = query.CategoryId,
                    CategoryName = query.CategoryName,
                    CategoryDesc = query.CategoryDesc,
                    CategoryIcon = query.CategoryIcon,
                };
            }
            return model;

        }


    }
}
