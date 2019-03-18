using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace We_Doku.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// This method takes a user to the home page
        /// </summary>
        /// <returns>Home page view</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}