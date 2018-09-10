using Microgaming.BAL;
using Microgaming.UiModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Microgaming.WebApp.Controllers
{
    public class CharityController : ApiController
    {
        [HttpGet]
        public List<CharityRecordUiModel> Get()
        {
            CharityRecordServices obj = new CharityRecordServices();
            return obj.GetRecords(User.Identity.GetUserId());
        }
    }
}
