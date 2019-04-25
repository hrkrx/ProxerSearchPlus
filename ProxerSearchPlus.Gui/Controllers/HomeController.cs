using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProxerSearchPlus.Gui.Models;
using ProxerSearchPlus.Api.Controller.Proxer.v1;

namespace ProxerSearchPlus.Gui.Controllers
{
    public class HomeController : Controller
    {
        private static ApiClient _proxer;

        static HomeController() {
            var db = new  ProxerSearchPlus.Api.Caching.Database.MongoDB.MongoDBConnector();
            _proxer = ApiClient.GetInstance(db);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string query)
        {
            var searchResult = _proxer.Search(query).GetAwaiter().GetResult().data;
            return View(searchResult);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
