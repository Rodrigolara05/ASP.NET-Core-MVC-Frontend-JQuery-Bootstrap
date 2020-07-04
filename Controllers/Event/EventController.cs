using Event_Soft_FrontEnd.Controllers.Category;
using Event_Soft_FrontEnd.Controllers.User;
using Event_Soft_FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_Soft_FrontEnd.Controllers.Event
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
          CategoryModel[] listCategories = CategoryConnection.GetCategories();
            EventModel[] listEvents = EventConnection.GetEvents();
            ViewBag.listEvents = listEvents;
          ViewBag.listCategories = listCategories;
            return View();
        }

        public IActionResult EventDetail(string id)
        {
          
            EventModel eventModel = EventConnection.InformationEvent(id);
            ViewBag.eventInformation = eventModel;
            return View();
        }

        public IActionResult CreateEvents()
        {
            string token = HttpContext.Session.GetString("Token");
            UserModel userModel = UserConnection.InformationUser(token);
            ViewBag.userInformation = userModel;


            return View();
        }
        [HttpPost]
        public IActionResult CreateEvents(string name, string image, CategoryModel[] categories, string start, string end, string address, string referenceLocation, Zone[] zona)
        {
            bool result = false;
           
            
           result = EventConnection.CreateEvent(name, image,  categories, start, end, address, referenceLocation, zona);
            

            return result ? RedirectToAction("InformationPublisherEvent","User") : RedirectToAction("CreateEvents", "Event");
        }
    }
}
