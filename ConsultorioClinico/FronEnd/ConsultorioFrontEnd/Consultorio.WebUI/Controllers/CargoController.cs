using Consultorio.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Consultorio.WebUI.Controllers
{
    public class CargoController : Controller
    {
        private static string _baseurl;

        public CargoController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;

        }

        public async Task<IActionResult> Index()
        {
            List<CargoViewModel> listado = new List<CargoViewModel>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Cargo/List");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    listado = JsonConvert.DeserializeObject<List<CargoViewModel>>(jsonResponse);
                }
                return View(listado);
            }
        }
    }
}
