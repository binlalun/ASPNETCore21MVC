using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ASPNETCore21MVC.Models;
using Microsoft.Extensions.Options;

namespace ASPNETCore21MVC.Controllers
{
    public class HomeController : Controller
    {
        //public IAppSettings A1 { get; }
        //public IAppSettingsScoped A2 { get; }
        //public IAppSettingsSingleton A3 { get; }

        //public HomeController(IAppSettings a1, IAppSettingsScoped a2, IAppSettingsSingleton a3)
        //{
        //    A1 = a1;
        //    A2 = a2;
        //    A3 = a3;
        //}

        public IOptionsSnapshot<AppSettings> appSettings { get; set; }

        public HomeController(IOptionsSnapshot<AppSettings> settings)
        {
            this.appSettings = settings;
        }

        //public IActionResult Test1()
        //{
        //    return Content(A1.Name);
        //}

        //public IActionResult Test2()
        //{
        //    return Content(A2.Name);
        //}

        //public IActionResult Test3()
        //{
        //    return Content(A3.Name);
        //}


        public IActionResult Index()
        {
            //HttpContext.Session.
            return Content(this.appSettings.Value.IP);
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
