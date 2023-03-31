using Consultorio.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Consultorio.WebUI.Controllers
{
    public class ReportesController : Controller
    {
        private static string _baseurl;

        public ReportesController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("ConsultasReporte")]
        public async Task<IActionResult> ConsultasReporte()
        {
            ViewBag.Resultado = TempData["cons"];

            List<ConsultasReportesViewModel> listado = new List<ConsultasReportesViewModel>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Consultas/ListReporte");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];


                    listado = JsonConvert.DeserializeObject<List<ConsultasReportesViewModel>>(jsonArray.ToString());


                }
                return View(listado);
            }
        }
    }
}
