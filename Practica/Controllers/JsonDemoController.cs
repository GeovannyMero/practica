using Practica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Practica.Controllers
{
    public class JsonDemoController : Controller
    {
        //
        // GET: /JsonDemo/
        public ActionResult Index()
        {
            GetUsersData();
            return View();
        }
        public JsonResult WelcomeNote()
        {
            bool isAdmin = false;
            string output = isAdmin ? "Welcome to the Admin User" : "Welcome to the User";
            return Json(output, JsonRequestBehavior.AllowGet);

        }

        private List<UserModel> GetUsers()
        {
            var usersList = new List<UserModel>  
            {  
                new UserModel  
                {  
                    UserId = 1,  
                    UserName = "Ram",  
                    Company = "Mindfire Solutions"  
                },  
                new UserModel  
                {  
                    UserId = 1,  
                    UserName = "chand",  
                    Company = "Mindfire Solutions"  
                },  
                new UserModel  
                {  
                    UserId = 1,  
                    UserName = "Abc",  
                    Company = "Abc Solutions"  
                }  
            };

            return usersList;
        }

        public JsonResult GetUsersData()
        {
            var users = GetUsers();
            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UpdateUsersDetail(string usersJson)
        {
            var js = new JavaScriptSerializer();
            UserModel[] user = js.Deserialize<UserModel[]>(usersJson);
            
            //TODO: user now contains the details, you can do required operations  
            return Json("User Details are updated");
        }  
    }
}