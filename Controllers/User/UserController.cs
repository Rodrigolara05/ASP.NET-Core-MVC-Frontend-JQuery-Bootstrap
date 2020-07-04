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
            try { 
                HttpContext.Session.SetString("Token", authModel.Token); 
            }
            catch (Exception)
            {

            }
        }
        private void SaveRefreshToken(AuthModel authModel)
        {
            try
            {
                HttpContext.Session.SetString("RefreshToken", authModel.RefreshToken);
            }
            catch (Exception)
            {

            }
           
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
            if (result!="")
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
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("Token", "");
            HttpContext.Session.SetString("RefreshToken", "");
            return RedirectToAction("Index", "Event");
        }

        public IActionResult Information()
        {
            string token = HttpContext.Session.GetString("Token");
            UserModel userModel = UserConnection.InformationUser(token);
            ViewBag.userInformation = userModel;
 
            return View();
        }

        public IActionResult InformationPublisherEvents()
        {
            string token = HttpContext.Session.GetString("Token");
            UserModel userModel = UserConnection.InformationPublisherEvent(token);
            ViewBag.userInformationEvent = userModel;
            UserModel userModel2 = UserConnection.InformationUser(token);
            ViewBag.userInformation = userModel2;

            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
