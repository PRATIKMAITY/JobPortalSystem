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
                var query = _db.Users.Where(a => a.UserId.ToString() == AddUser.UserId.ToString()).SingleOrDefault();

                //UserId = Guid.NewGuid(),
                query.UserName = AddUser.UserName;
                query.Gender = AddUser.Gender;
                query.UserContactNo = AddUser.UserContactNo;
                query.UserEmail = AddUser.UserEmail;
                query.Addr = AddUser.Addr;
                query.DOB = AddUser.DOB;
                query.C10thBoard = AddUser.C10thBoard;
                query.C10thPercentage = AddUser.C10thPercentage;
                query.HSBoard = AddUser.HSBoard;
                query.HSPercentage = AddUser.HSPercentage;
                query.UGUnivercity = AddUser.UGUnivercity;
                query.UGCollege = AddUser.UGCollege;
                query.UGPercentage = AddUser.UGPercentage;
                query.PGUniversity = AddUser.PGUniversity;
                query.PGCollege = AddUser.PGCollege;
                query.PGPercentage = AddUser.PGPercentage;
                query.Skill1 = AddUser.Skill1;
                query.Skill2 = AddUser.Skill2;
                   query.Skill3 = AddUser.Skill3;
                query.CurrentLoc = AddUser.CurrentLoc;
                query.CurrentDesignation = AddUser.CurrentDesignation;
                query.CurrentOfcName = AddUser.CurrentOfcName;
                query.CurrentySalary = AddUser.CurrentySalary;
                query.TotalYearOfExp = AddUser.TotalYearOfExp;
                query.AlternatePhno = AddUser.AlternatePhno;

                query.C10thpassoutyear = AddUser.C10thpassoutyear;
                query.C10thSchoolName = AddUser.C10thSchoolName;
                query.C12thpassoutyear = AddUser.C12thpassoutyear;
                query.C12thSchoolName = AddUser.C12thSchoolName;

                query.PGPassoutYear = AddUser.PGPassoutYear;
                query.UGPassoutYear = AddUser.UGPassoutYear;
                    
               
                
                _db.SaveChanges();
                return "User Edited Successfully";
            }
            catch
            {
                return "Some error occured";
            }
        }


        [HttpPost]
        [ActionName("AddorChangeCV")]
        public string AddCV([FromBody]UserViewModel AddUser)
        {
            try
            {
                var query = _db.Users.Where(a => a.UserId.ToString() == AddUser.UserId.ToString()).SingleOrDefault();

                query.CvPath = AddUser.CvPath;
               


                _db.SaveChanges();
                return "CV add or EditSuccessfully";
            }
            catch
            {
                return "Some error occured";
            }

        }

        [HttpPost]
        [ActionName("AddorChangePhoto")]
        public string Addphoto([FromBody] UserViewModel AddUser)
        {
            try
            {
                var query = _db.Users.Where(a => a.UserId.ToString() == AddUser.UserId.ToString()).SingleOrDefault();

                query.ProfilePicPath = AddUser.ProfilePicPath;



                _db.SaveChanges();
                return "Photo add or EditSuccessfully";
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

        //......Get User By aspuserId.............................
        [HttpGet]
        [ActionName("GetUserById")]
        public async Task<UserViewModel> GetUserById(string UId)
        {

            var query = await _db.Users.Where(a =>a.aspnetuserid.ToString() == UId).SingleOrDefaultAsync();
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
                    C10thpassoutyear=query.C10thpassoutyear,
                    C10thSchoolName=query.C10thSchoolName,
                    C12thpassoutyear=query.C12thpassoutyear,
                    C12thSchoolName=query.C12thSchoolName,
                    Joinedon=query.Joinedon,
                    PGPassoutYear=query.PGPassoutYear,
                    UGPassoutYear=query.UGPassoutYear,
                    ProfilePicPath=query.ProfilePicPath,
                };
            }
            return model;

        }

        [HttpGet]
        [ActionName("ApplyJobChecking")]
        public  string CheckJobapply(string JobId,string userid)
        {
            var query = _db.ApplyJobs.Where(a => a.UserId.ToString() == userid && a.JobId.ToString()==JobId).SingleOrDefault();

            if(query!=null)
            {
                return "Already Applied";
            }

            return "Not Applied";


        }
    }
}
