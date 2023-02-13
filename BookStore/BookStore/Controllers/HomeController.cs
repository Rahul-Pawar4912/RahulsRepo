using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace BookStore.Controllers
{
    public class HomeController:Controller
    {
        [ViewData]
        public string Title { get; set; }
        public ViewResult Index()
        {
            //ViewBag.Name = "Rahul";
            //dynamic data = new ExpandoObject();
            //data.Id = 1;
            //data.Name1 = "Rahul";
            //ViewBag.Data = data;
            // ViewData["Title"] = "Home";
            Title = "Home from Controller";
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
