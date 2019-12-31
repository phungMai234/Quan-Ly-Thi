using BLL;
using Models;
//using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ABCUnit.Controllers
{
    public class LoginAdminController : ApiController
    {
        AdminBLL adminBLL = new AdminBLL();
        
        [Route("loginadmin")]
        [HttpPost]
        public AjaxResult login(Login login)
        {
            
            var _ajax = new AjaxResult();
            //_ajax.Data = adminBLL.GetAdmins();
            //string myPass = "115511494";
            //string mySalt = BCrypt.Net.BCrypt.GenerateSalt();
            //string myHash = BCrypt.Net.BCrypt.HashPassword(myPass, mySalt);
            //_ajax.Message = myHash;
            //bool doesPasswordMatch = BCrypt.Net.BCrypt.Equals(login.UserPassword, myHash);
            var display = adminBLL.GetAdmins().Where(m => m.AdminCode == login.UserName && BCrypt.Net.BCrypt.Verify(login.UserPassword, m.PassWord)).FirstOrDefault();
            _ajax.Data = display;
            if (display != null)
            {
                //_ajax.Message = "CORRECT UserNAme and Password";
                
                _ajax.Success = true;
            }
            else
            {
                //_ajax.Message = "INCORRECT UserName or Password";
                _ajax.Success = false;
            }
            return _ajax;
        }

        StudentBLL studentBLL = new StudentBLL();

        [Route("loginstudent")]
        [HttpPost]
        public AjaxResult loginStudent(Login login)
        {

            var _ajax = new AjaxResult();
           
            //var display = "";
            var display = studentBLL.GetStudentTwo().Where(m => m.StudentCode == login.UserName && BCrypt.Net.BCrypt.Verify(login.UserPassword, m.PassWord)).FirstOrDefault();
            _ajax.Data = display;
            if (display != null)
            {
                //_ajax.Message = "CORRECT UserNAme and Password";

                _ajax.Success = true;
            }
            else
            {
                //_ajax.Message = "INCORRECT UserName or Password";
                _ajax.Success = false;
            }
            return _ajax;
        }
    }
}
