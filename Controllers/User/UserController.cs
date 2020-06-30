using Event_Soft_FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Event_Soft_FrontEnd.Models.Authorization;

namespace Event_Soft_FrontEnd.Controllers.User
{
    public class UserController : Controller
    {
        private void SaveToken(AuthModel authModel)
        {
            HttpContext.Session.SetString("Token", authModel.Token);
        }
        private void SaveRefreshToken(AuthModel authModel)
        {
            HttpContext.Session.SetString("RefreshToken", authModel.RefreshToken);
        }

        private void saveInSession(string response)
        {
            AuthModel authModel = AuthModel.FromJson(response);
            SaveToken(authModel);
            SaveRefreshToken(authModel);
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            string result = UserConnection.Login(username,password);
            saveInSession(result);
            
            //string res = HttpContext.Session.GetString("Token");

            return result!="" ? RedirectToAction("Index","Event") : RedirectToAction("Login");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string username, string firstname,string lastname, string email, string password, string type)
        {
            bool result = false;
            if (type == "Shopper")
            {
                result = UserConnection.RegisterShopper(username, firstname, lastname, email, password);
            }
            else if (type == "Publisher")
            {
                result = UserConnection.RegisterPublisher(username, firstname, lastname, email, password);
            }

            return result? RedirectToAction("Login") : RedirectToAction("Register");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
