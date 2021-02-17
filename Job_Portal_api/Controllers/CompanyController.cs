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
using System.Collections.Concurrent;

namespace Job_Portal_api.Controllers
{
    public class CompanyController : ApiController
    {

        private jobpotaldbEntities _db = new jobpotaldbEntities();
        
        [HttpGet]
        [ActionName("GetAllCompany")]
        public async Task<IEnumerable<CompanyViewModel>> GetAllCompany()
        {
            var query = await _db.Companies.ToListAsync();

            var model = new List<CompanyViewModel>();
            foreach (var item in query)
            {
                model.Add(new CompanyViewModel
                {
                   ComapanyId=item.ComapanyId,
                   CompanyBranchAddr=item.CompanyBranchAddr,
                   CompanyContactNo=item.CompanyContactNo,
                   CompanyDesc=item.CompanyDesc,
                   CompanyEmail=item.CompanyEmail,
                   CompanyName=item.CompanyName,

                });
            }


            return model;
        }

        //get company id by jobid............
        [HttpGet]
        [ActionName("GetCompanyDetailsByJobId")]
        public async Task<CompanyViewModel> GetJobById(string jId)
        {
            var query = await _db.JobDescs.SingleOrDefaultAsync(a => a.JobId.ToString() == jId);
            var query2 = await _db.Companies.SingleOrDefaultAsync(a =>a.ComapanyId == query.ComapanyId);
            var model = new CompanyViewModel();
            if (query != null)
            {
                 model=new CompanyViewModel
                {
                    ComapanyId = query2.ComapanyId,
                    CompanyBranchAddr = query2.CompanyBranchAddr,
                    CompanyContactNo = query2.CompanyContactNo,
                    CompanyDesc = query2.CompanyDesc,
                    CompanyEmail = query2.CompanyEmail,
                    CompanyName = query2.CompanyName,
                };

            }
            return model;
        }
        

    }
}
