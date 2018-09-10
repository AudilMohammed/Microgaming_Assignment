using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Microgaming.WebApp.Controllers
{
    public class LoginController : System.Web.Mvc.Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Login";

            return View();
        }

        public ActionResult Register()
        {
            ViewBag.Title = "Register";

            return View();
        }
    }
}
