using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProxerSearchPlus.Gui.Models;
using ProxerSearchPlus.Api.Controller.Proxer.v1;
using ProxerSearchPlus.Api.Model.Proxer.v1;

namespace ProxerSearchPlus.Gui.Controllers
{
    public class DetailsController : Controller
    {
        private static ApiClient _proxer;

        static DetailsController() {
            var db = new  ProxerSearchPlus.Api.Caching.Database.MongoDB.MongoDBConnector();
            _proxer = ApiClient.GetInstance(db);
        }

        public IActionResult Entry()
        {
            
            return View();
        }
    }
}