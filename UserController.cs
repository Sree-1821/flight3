using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebFronted.Models;
using WebFronted.Repository;

namespace WebFronted.Controllers
{
    public class UserController : Controller
    {
        public string test()
        {
            return "Hello";
        }
        // GET: User
        public async Task<ActionResult> Index()
        {
            List<UserViewModel> users = new List<UserViewModel>();
            var service = new ServiceRepository();
            {
                using (var response = service.GetResponse("Users"))
                {
                    string apiResponse
                        = await response.Content.ReadAsStringAsync();
                    users = JsonConvert.DeserializeObject
                        <List<UserViewModel>>(apiResponse);
                }
            }
            return View(users);
        }
        public async Task<ActionResult>Create(UserViewModel user)
        {
            if(ModelState.IsValid)
            {
                UserViewModel newUser = new UserViewModel();    
                var service = new ServiceRepository();
                {
                    using (var response = service.PostResponse("User", user))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync(); 
                        newUser = JsonConvert.DeserializeObject<UserViewModel>(apiResponse);
                    }
                }
                return RedirectToAction("Index");
            }
            return View(user);
        }
      
    }
}