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
            EventModel[] listEvents = EventConnection.GetEvents();
            ViewBag.listEvents = listEvents;
            return View();
        }
        public IActionResult EventDetail(string id)
        {
          
            EventModel eventModel = EventConnection.InformationEvent(id);
            ViewBag.eventInformation = eventModel;
            return View();
        }
    }
}
