using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private static string _baseurl;

        public LoginController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;

        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
