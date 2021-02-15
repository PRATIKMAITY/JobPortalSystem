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
    public class JobController : ApiController
    {
        private jobpotaldbEntities _db = new jobpotaldbEntities();

        [HttpGet]
        [ActionName("GetAllJob")]
        public async Task<IEnumerable<JobViewModel>> GetAllJob()
        {
            var query = await _db.JobDescs.ToListAsync();

            var model = new List<JobViewModel>();
            foreach (var item in query)
            {
                model.Add(new JobViewModel
                {
                    CategoryId=item.CategoryId??0,
                    ComapanyId=item.ComapanyId??default,
                    ExpextedSalary=item.ExpextedSalary,
                    JobDesc1=item.JobDesc1,
                    JobId=item.JobId,
                    JobLoc=item.JobLoc,
                    JobName=item.JobName,
                    JobPos=item.JobPos,
                    JobSkill=item.JobSkill,
                    JobType=item.JobType,
                    MinQulafication=item.MinQulafication,
                    JobCategory=getcategorybyjob(item.CategoryId??0),

                });
            }


            return model;
        }

        protected CategoryViewModel getcategorybyjob(int cid)

        {
            var query = _db.JobCategories.Where(a => a.CategoryId ==cid).SingleOrDefault();
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

        // get category by id..............................
        [HttpGet]
        [ActionName("GetCategoryById")]
        public async Task<CategoryViewModel> GetCategoryById(string CId)
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

        // HTTPPOST apply for insert job .............................
        [HttpPost]
        [ActionName("AddJobDetails")]
        public string AddJobDetails( [FromBody]JobViewModel AddJob)
        {
            try
            {
                var model = new JobDesc
                {
                    JobId = Guid.NewGuid(),
                    CategoryId = AddJob.CategoryId,
                    ExpextedSalary = AddJob.ExpextedSalary,
                    JobDesc1 = AddJob.JobDesc1,
                    JobLoc = AddJob.JobLoc,
                    JobName = AddJob.JobName,
                    JobPos = AddJob.JobPos,
                    JobSkill = AddJob.JobSkill,
                    JobType = AddJob.JobType,
                    MinQulafication = AddJob.MinQulafication,
                    ComapanyId = AddJob.ComapanyId,
                };
                _db.JobDescs.Add(model);
                _db.SaveChanges();
                return "Job Added Successfully";
            }
            catch
            {
                return "Some error occured";
            }
        }
        //...get job by Category Id..........................
        [HttpGet]
        [ActionName("GetJobById")]
        public async Task<List<JobViewModel>> GetJobById(string CId)
        {
            var query = await _db.JobDescs.Where(a => a.CategoryId.ToString() == CId).ToListAsync();
            var model = new List<JobViewModel>();
            if (query != null)
            {
                foreach (var item in query)
                {

                    model.Add(new JobViewModel
                    {
                        JobId = item.JobId,
                        ComapanyId = item.ComapanyId ?? default,
                        ExpextedSalary = item.ExpextedSalary,
                        JobDesc1 = item.JobDesc1,
                        JobName = item.JobName,
                        JobLoc = item.JobLoc,
                        JobPos = item.JobPos,
                        JobSkill = item.JobSkill,
                        JobType = item.JobType,
                        MinQulafication = item.MinQulafication,
                        CategoryId = item.CategoryId ?? 0,
                    });
                }
            }
            return model;
        }

    }
}
