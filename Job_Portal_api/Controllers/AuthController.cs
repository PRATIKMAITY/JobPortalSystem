using Job_Portal_api.Data;
using Job_Portal_api.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace Job_Portal_api.Controllers
{
    public class AuthController : ApiController
    {
        private jobpotaldbEntities _db = new jobpotaldbEntities();

        [HttpPost]
        [ActionName("Register")]
        public async Task<UserAuthModel> Register([FromBody] RegisterModel Input)
        {
            if (ModelState.IsValid)
            {
                var checkuser = await _db.AspNetUsers.Where(a => a.UserName == Input.Email).SingleOrDefaultAsync();
                if (checkuser == null)
                {
                    var role = await _db.AspNetRoles.Where(a => a.Name == "Student").SingleOrDefaultAsync();
                    string roleid;
                    if (role != null)
                    {
                        roleid = role.Id;
                    }
                    else
                    {
                        roleid = Guid.NewGuid().ToString();

                        role = new AspNetRole();
                        role.Name = "Student";
                        role.Id = roleid;
                        _db.AspNetRoles.Add(role);
                    }

                    var aspnetuser = new AspNetUser
                    {
                        Email = Input.Email,
                        UserName = Input.Email,
                        PhoneNumber = Input.PhoneNumber,
                        Id = Guid.NewGuid().ToString(),
                        Roleid=roleid,
                        
                    };
                    


                    aspnetuser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(Input.Password);
                    _db.AspNetUsers.Add(aspnetuser);
                    //var aspnetuserRoles = new IdentityUserRole
                    //{
                    //    RoleId = role.Id,
                    //    UserId = aspnetuser.Id
                    //};


                    var agent = new User
                    {
                        UserId = Guid.NewGuid(),
                        UserName = Input.Name,
                        //Joinedon = DateTime.Now,
                        UserEmail = Input.Email,
                        UserContactNo = Input.PhoneNumber,
                        ProfilePicPath = "default_user.jpg",
                        aspnetuserid = aspnetuser.Id,
                        

                    };
                    _db.Users.Add(agent);
                    //add to role
                    try { 
                     _db.SaveChanges();
                    }

                    catch(Exception ex)
                    {
                        return new UserAuthModel
                        {
                            Succeeded = false,
                            Message = ex.Message,
                        };

                    }
                    return new UserAuthModel
                    {
                       
                        UserId = aspnetuser.Id,
                        UserName = Input.Email,
                        Succeeded = true,
                        
                    };
                }
                else
                {
                    return new UserAuthModel
                    {
                        Succeeded = false,
                        Message = "User Already Exists."
                    };
                }
            }
            return new UserAuthModel
            {
                Succeeded = false
            };
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<UserAuthModel> Login([FromBody] LoginModel Input)
        {
            if (ModelState.IsValid)
            {
                var user = await _db.AspNetUsers.Where(a => a.Email == Input.Email).SingleOrDefaultAsync();
                if (user == null)
                {
                    return new UserAuthModel
                    {
                        Succeeded = false,
                        Message = "User not registered."
                    };
                }
                else
                {
                    var getrole = await _db.AspNetRoles.Where(a => a.Id == user.Roleid).SingleOrDefaultAsync();
                    string rolename = getrole.Name;
                    bool result = BCrypt.Net.BCrypt.Verify(Input.Password,user.PasswordHash);
                    if (result)
                    {
                        

                        return new UserAuthModel
                        {
                            Succeeded = true,
                            UserId = user.Id,
                            rolename = rolename,
                            UserName = Input.Email,
                        };
                    }
                    else
                    {
                        return new UserAuthModel
                        {
                            Succeeded = false,
                            Message = "Invalid login attempt."
                        };
                    }
                }
            }
            return new UserAuthModel
            {
                Succeeded = false,
                Message = "Some error occurred. Please try again later."
            };
        }


    }
}
