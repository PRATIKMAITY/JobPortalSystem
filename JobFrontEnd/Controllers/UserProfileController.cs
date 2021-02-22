using JobFrontEnd.Models;
using Newtonsoft.Json;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;




namespace JobFrontEnd.Controllers
{
    public class UserProfileController : Controller
    {
        private const string BaseUrl = "https://localhost:44359/api/";
        static HttpClient client = new HttpClient();


        // Post: UserProfile
        public ActionResult Index()
        {
            var model = new UserViewModel();
            return View();
        }

        [HttpGet]
        public  async Task<ActionResult> AddEditprofile()
        {
            string loggedin;
            try
            {

                loggedin = Request.Cookies["LogInFlag"].IfNotNull(arg => arg.Value);


            }
            catch (System.NullReferenceException)
            {
                // not logged in or null id.
                loggedin = "0";
            }

            if (loggedin == "1")
            {
                ViewBag.loginflagmvc = 1;
            }


            object userid;
            try
            {
                userid = Request.Cookies["UserId"].Value;

            }
            catch (System.NullReferenceException ex)
            {
                // not logged in or null id.
                return RedirectToAction("Index", "Home");
            }

            ViewBag.UserId = userid;
            UserViewModel model = new UserViewModel();

            var streamTask =await client.GetAsync(BaseUrl + "User/GetUserById/?UId=" + userid);
            if (streamTask.IsSuccessStatusCode)
            {

                var response = streamTask.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<UserViewModel>(response);
            }

            return View(model);
            
        }




        [HttpPost]
        public async Task<ActionResult> AddEditUser(UserViewModel model)
        {
            if(model.flag.ToString()=="1")
            {
                string filename = Path.GetFileNameWithoutExtension(model.profilefile.FileName);
                string extension = Path.GetExtension(model.profilefile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssfff") + model.UserId + extension;
                string flagiconprofilepicnamename = filename;
                filename = Path.Combine(Server.MapPath("~/ProfilePic/"), filename);
                model.profilefile.SaveAs(filename);


                var model1 = new UserViewModelApiSend()
                {
                    
                    UserId = model.UserId,
                    ProfilePicPath = flagiconprofilepicnamename,
                    

                };


                var postTask = await client.PostAsJsonAsync<UserViewModelApiSend>(BaseUrl + "User/AddorChangePhoto", model1);

                if (postTask.IsSuccessStatusCode)
                {
                    return Content(@"<script language='javascript' type='text/javascript'>
                           alert('Photo Added');
                         window.location.href='/UserProfile/AddEditprofile/'
                         </script>
                      ");
                }
                else
                {
                    return Content(@"<script language='javascript' type='text/javascript'>
                         alert('Some error occurred. Please try again later');
                         window.location.href='/UserProfile/AddEditprofile/'
                         </script>
                      ");
                }


            }

            else if(model.flag.ToString()=="2")
            {
                string filename1 = Path.GetFileNameWithoutExtension(model.Cvfile.FileName);
                string extension1 = Path.GetExtension(model.Cvfile.FileName);
                filename1 = filename1 + DateTime.Now.ToString("yymmssfff") + model.UserId + extension1;
                string CVname = filename1;
                filename1 = Path.Combine(Server.MapPath("~/Cv/"), filename1);
                model.profilefile.SaveAs(filename1);

                var model1 = new UserViewModelApiSend()
                {
                    UserId = model.UserId,
                    cvpath = CVname,

                };


                var postTask = await client.PostAsJsonAsync<UserViewModelApiSend>(BaseUrl + "Agent/DocumentUpload", model1);

                if (postTask.IsSuccessStatusCode)
                {
                    return Content(@"<script language='javascript' type='text/javascript'>
                         alert('CV Added');
                         window.location.href='/UserProfile/AddEditprofile/'
                         </script>
                      ");
                }
                else
                {
                    return Content(@"<script language='javascript' type='text/javascript'>
                          alert('Profile Edited');
                         window.location.href='/UserProfile/AddEditprofile/'
                         </script>
                      ");
                }




            }

            else if(model.flag.ToString()=="3")
            {
                var model1 = new UserViewModelApiSend()
                {
                    UserName = model.UserName,
                    UserId = model.UserId,
                    Addr = model.Addr,
                    AlternatePhno = model.AlternatePhno,
                    C10thBoard = model.C10thBoard,
                    C10thpassoutyear = model.C10thpassoutyear,
                    C10thPercentage = model.C10thPercentage,
                    C10thSchoolName = model.C10thSchoolName,
                    C12thpassoutyear = model.C12thpassoutyear,
                    C12thSchoolName = model.C12thSchoolName,
                    CurrentDesignation = model.CurrentDesignation,
                    CurrentLoc = model.CurrentLoc,
                    CurrentOfcName = model.CurrentOfcName,
                    CurrentySalary = model.CurrentySalary,

                    DOB = model.DOB,
                    Gender = model.Gender,
                    HSBoard = model.HSBoard,
                    HSPercentage = model.HSPercentage,
                    PGCollege = model.PGCollege,
                    PGPassoutYear = model.PGPassoutYear,
                    PGPercentage = model.PGPercentage,
                    PGUniversity = model.PGUniversity,
                    Skill1 = model.Skill1,
                    Skill2 = model.Skill2,
                    Skill3 = model.Skill3,
                    TotalYearOfExp = model.TotalYearOfExp,
                    UGCollege = model.UGCollege,
                    UGPassoutYear = model.UGPassoutYear,
                    UGPercentage = model.UGPercentage,
                    UGUnivercity = model.UGUnivercity,
                    UserContactNo = model.UserContactNo,
                    UserEmail = model.UserEmail,
                   
                };


                var postTask = await client.PostAsJsonAsync<UserViewModelApiSend>(BaseUrl + "User/AddUserDetails", model1);

                if (postTask.IsSuccessStatusCode)
                {
                    return Content(@"<script language='javascript' type='text/javascript'>
                         alert('Profile Edited');
                         window.location.href='/UserProfile/AddEditprofile/'
                         </script>
                      ");
                }
                else
                {
                    return Content(@"<script language='javascript' type='text/javascript'>
                         alert('Some error occurred. Please try again later');
                         window.location.href='/UserProfile/AddEditprofile/'
                         </script>
                      ");
                }


            }

            else
            {
                return Content(@"<script language='javascript' type='text/javascript'>
                         alert('Error occured');
                         window.location.href='/admin/index/'
                         </script>
                      ");
            }

        }

            


            

            
            
               

            }
        }

 
