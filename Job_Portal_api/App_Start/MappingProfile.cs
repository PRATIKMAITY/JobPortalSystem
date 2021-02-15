using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Job_Portal_api.Data;
using Job_Portal_api.Model;


namespace Job_Portal_api.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
            {
            CreateMap<JobCategory,CategoryViewModel>();
            }
    }
}