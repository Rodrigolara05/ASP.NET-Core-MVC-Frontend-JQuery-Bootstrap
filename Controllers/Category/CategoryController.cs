using Event_Soft_FrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Event_Soft_FrontEnd.Controllers.Category
{
    public class CategoryController : Controller
    {
        public IActionResult CategoryDetail(string name)
        {
            CategoryModel[] listCategories = CategoryConnection.GetCategories();
            CategoryModel categoryModel = CategoryConnection.InformationCategory(name);
            ViewBag.listCategories = listCategories;
            ViewBag.categoryInformation = categoryModel;
            return View();
        }
        public IActionResult Suscribe(string name)
        {
            string token = HttpContext.Session.GetString("Token");
            if (token != null)
            {
                bool subscribe = CategoryConnection.Suscribe(token, name);
                return RedirectToAction("CategoryDetail", new { name = name });
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
    }
}
