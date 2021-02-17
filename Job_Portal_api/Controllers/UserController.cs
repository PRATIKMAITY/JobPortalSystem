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
    public class UserController : ApiController
    {
        private jobpotaldbEntities _db = new jobpotaldbEntities();
        //......HTTPPOST apply for insert User Details ...................
        
        
        [HttpPost]
        [ActionName("AddUserDetails")]
        public string AddUserDetails([FromBody]UserViewModel AddUser)
        {
            try
            {
                var model = new User
                {
                    UserId = Guid.NewGuid(),
                    UserName = AddUser.UserName,
                    Gender = AddUser.Gender,
                    UserContactNo = AddUser.UserContactNo,
                    UserEmail = AddUser.UserEmail,
                    Addr = AddUser.Addr,
                    DOB = AddUser.DOB,
                    C10thBoard = AddUser.C10thBoard,
                    C10thPercentage = AddUser.C10thPercentage,
                    HSBoard = AddUser.HSBoard,
                    HSPercentage = AddUser.HSPercentage,
                    UGUnivercity = AddUser.UGUnivercity,
                    UGCollege = AddUser.UGCollege,
                    UGPercentage = AddUser.UGPercentage,
                    PGUniversity = AddUser.PGUniversity,
                    PGCollege = AddUser.PGCollege,
                    PGPercentage = AddUser.PGPercentage,
                    Skill1 = AddUser.Skill1,
                    Skill2 = AddUser.Skill2,
                    Skill3 = AddUser.Skill3,
                    CurrentLoc = AddUser.CurrentLoc,
                    CurrentDesignation = AddUser.CurrentDesignation,
                    CurrentOfcName = AddUser.CurrentOfcName,
                    CurrentySalary = AddUser.CurrentySalary,
                    TotalYearOfExp = AddUser.TotalYearOfExp,
                    AlternatePhno = AddUser.AlternatePhno,
                    CvPath = AddUser.CvPath,


                };
                _db.Users.Add(model);
                _db.SaveChanges();
                return "User Added Successfully";
            }
            catch
            {
                return "Some error occured";
            }
        }

        //......get all users......................
        [HttpGet]
        [ActionName("GetAllUser")]
        public async Task<IEnumerable<UserViewModel>> GetAllUser()
        {
            var query = await _db.Users.ToListAsync();

            var model = new List<UserViewModel>();
            foreach (var item in query)
            {
                model.Add(new UserViewModel
                {
                    UserId = item.UserId,
                    UserName = item.UserName,
                    UserContactNo = item.UserContactNo,
                    UserEmail = item.UserEmail,
                    Gender = item.Gender,
                    Addr = item.Addr,
                    DOB = item.DOB,
                    C10thBoard = item.C10thBoard,
                    C10thPercentage = item.C10thPercentage,
                    HSBoard = item.HSBoard,
                    HSPercentage = item.HSPercentage,
                    UGUnivercity = item.UGUnivercity,
                    UGCollege = item.UGCollege,
                    UGPercentage = item.UGPercentage,
                    PGUniversity = item.PGUniversity,
                    PGCollege = item.PGCollege,
                    PGPercentage = item.PGPercentage,
                    Skill1 = item.Skill1,
                    Skill2 = item.Skill2,
                    Skill3 = item.Skill3,
                    CurrentDesignation = item.CurrentDesignation,
                    CurrentLoc = item.CurrentLoc,
                    CurrentOfcName = item.CurrentOfcName,
                    CurrentySalary = item.CurrentySalary,
                    TotalYearOfExp = item.TotalYearOfExp,
                    AlternatePhno = item.AlternatePhno,
                    CvPath = item.CvPath,
                }) ;
            }
            return model;
        }

        //......Get User By Id.............................
        [HttpGet]
        [ActionName("GetUserById")]
        public async Task<UserViewModel> GetUserById(string UId)
        {

            var query = await _db.Users.Where(a =>a.UserId.ToString() == UId).SingleOrDefaultAsync();
            var model = new UserViewModel();
            if (query != null)
            {

                model = new UserViewModel
                {
                    UserId = query.UserId,
                    UserName = query.UserName,
                    UserContactNo = query.UserContactNo,
                    UserEmail = query.UserEmail,
                    Gender = query.Gender,
                    Addr = query.Addr,
                    DOB = query.DOB,
                    C10thBoard = query.C10thBoard,
                    C10thPercentage = query.C10thPercentage,
                    HSBoard = query.HSBoard,
                    HSPercentage = query.HSPercentage,
                    UGUnivercity = query.UGUnivercity,
                    UGCollege = query.UGCollege,
                    UGPercentage = query.UGPercentage,
                    PGUniversity = query.PGUniversity,
                    PGCollege = query.PGCollege,
                    PGPercentage = query.PGPercentage,
                    Skill1 = query.Skill1,
                    Skill2 = query.Skill2,
                    Skill3 = query.Skill3,
                    CurrentDesignation = query.CurrentDesignation,
                    CurrentLoc = query.CurrentLoc,
                    CurrentOfcName = query.CurrentOfcName,
                    CurrentySalary = query.CurrentySalary,
                    TotalYearOfExp = query.TotalYearOfExp,
                    AlternatePhno = query.AlternatePhno,
                    CvPath = query.CvPath,
                };
            }
            return model;

        }
    }
}
