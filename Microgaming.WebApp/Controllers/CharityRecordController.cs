using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Microgaming.WebApp.Controllers
{
    public class CharityRecordController : Controller
    {
        // GET: CharityRecord
        public ActionResult CharityRecord()
        {
            return View();
        }

        public ActionResult CreateCharityRecord()
        {
            return View();
        }
    }
}