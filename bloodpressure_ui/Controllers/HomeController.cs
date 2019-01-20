using System.Diagnostics;
using Bloodpressure_UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BloodpressureUI_NetCore.Controllers
{
    public class HomeController : Controller
    {
       private readonly IOptions<APIConnectionModel> appSettings;

       public HomeController(IOptions<APIConnectionModel> app)
        {
            appSettings = app;
            ApplicationSettings.WebAPIUrl = appSettings.Value.WebApiBaseUrl;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
