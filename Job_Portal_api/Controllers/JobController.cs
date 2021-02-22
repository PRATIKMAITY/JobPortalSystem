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
using AutoMapper.QueryableExtensions;

namespace Job_Portal_api.Controllers
{
    public class JobController : ApiController
    {
        private jobpotaldbEntities _db = new jobpotaldbEntities();

        //...... get all job.....................
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
                    CategoryId = item.CategoryId ?? 0,
                    ComapanyId = item.ComapanyId ?? default,
                    ExpextedSalary = item.ExpextedSalary,
                    JobDesc1 = item.JobDesc1,
                    JobId = item.JobId,
                    JobLoc = item.JobLoc,
                    JobName = item.JobName,
                    JobPos = item.JobPos,
                    JobSkill = item.JobSkill,
                    JobType = item.JobType,
                    MinQulafication = item.MinQulafication,
                    JobCategory = getcategorybyjob(item.CategoryId ?? 0),

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
        public CategoryViewModel GetCategoryById(string CId)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JobCategory, CategoryViewModel>();
            });
            var query = _db.JobCategories.Where(q => q.CategoryId.ToString() == CId).ProjectTo<CategoryViewModel>(config);
            return query.First();

            //var query = await _db.JobCategories.Where(a => a.CategoryId.ToString() == CId).SingleOrDefaultAsync();
            //var model = new CategoryViewModel();
            //if (query != null)
            //{

            //    model = new CategoryViewModel
            //    {
            //        CategoryId = query.CategoryId,
            //        CategoryName = query.CategoryName,
            //        CategoryDesc = query.CategoryDesc,
            //        CategoryIcon = query.CategoryIcon,
            //    };
            //}
            //return model;

        }

        // HTTPPOST apply for insert job .............................
        [HttpPost]
        [ActionName("InsertJobDetails")]
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
        [ActionName("GetJobByCategoryId")]
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

        //...get job by Job Id..........................
        [HttpGet]
        [ActionName("GetJobByJobId")]
        public JobViewModel GetJobByJobId(string JId)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<JobDesc, JobViewModel>();
                cfg.CreateMap<Company, CompanyViewModel>();
                cfg.CreateMap<JobCategory, CategoryViewModel>();
            });
            var query =  _db.JobDescs.Where(q => q.JobId.ToString() == JId).ProjectTo<JobViewModel>(config);
            return query.First();


            //var query = await _db.JobDescs.Where(a => a.JobId.ToString() == JId).SingleOrDefaultAsync();
            //var model = new JobViewModel();
            //if (query != null)
            //{
                

                    //model.Add(new JobViewModel
                    //{
                    //    JobId = query.JobId,
                    //    ComapanyId = query.ComapanyId ?? default,
                    //    ExpextedSalary = query.ExpextedSalary,
                    //    JobDesc1 = query.JobDesc1,
                    //    JobName = query.JobName,
                    //    JobLoc = query.JobLoc,
                    //    JobPos = query.JobPos,
                    //    JobSkill = query.JobSkill,
                    //    JobType = query.JobType,
                    //    MinQulafication = query.MinQulafication,
                    //    CategoryId = query.CategoryId ?? 0,
                    //});
               
            //}
            //return model;
        }

        //get job by location...................
        [HttpGet]
        [ActionName("GetJobByLocation")]
        public async Task<List<JobViewModel>> GetJobByLocation(string loc) 
        {
            var query = await _db.JobDescs.Where(a => a.JobLoc == loc).ToArrayAsync();
            var model =new List<JobViewModel>();
            if(query!=null)
            {
                foreach( var item in query)
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
                        CategoryId = item.CategoryId ?? default,

                    });
                }
            }
            return model;
        }

        
    }
}
