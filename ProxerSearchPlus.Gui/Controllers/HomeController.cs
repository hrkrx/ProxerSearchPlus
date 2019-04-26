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
    public class HomeController : Controller
    {
        private static ApiClient _proxer;

        static HomeController() {
            var db = new  ProxerSearchPlus.Api.Caching.Database.MongoDB.MongoDBConnector();
            _proxer = ApiClient.GetInstance(db);
            _proxer.ApiKey = System.IO.File.ReadAllText("api.key");
            _proxer.ApiUserAgent = "LtpDotnetCoreApiClient";
        }

        public IActionResult Index(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return View(new List<Entry>());
            }
            var searchResult = _proxer.Search(query, 100).GetAwaiter().GetResult();
            return View(searchResult.data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
