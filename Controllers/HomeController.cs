using System;
using Microsoft.AspNetCore.Mvc;

namespace Homemade.Controllers {

    public class HomeController : Controller
    {

        public IActionResult Index() {
            return View();
        }

    }

}