using Consultorio.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.WebUI.Controllers
{
    public class ConsultaController : Controller
    {
        private static string _baseurl;

        public ConsultaController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;

        }
        public async Task<IActionResult> Index()
        {
            List<ConsultaViewModel> listado = new List<ConsultaViewModel>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Consultas/List");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];

                    ViewBag.message = message;

                    listado = JsonConvert.DeserializeObject<List<ConsultaViewModel>>(jsonArray.ToString());
                }
                return View(listado);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            using (var httpClient = new HttpClient())
            {
                var responsePaci = await httpClient.GetAsync(_baseurl + "api/Paciente/List");
                //var responseEstado = await httpClient.GetAsync(_baseurl + "api/EstadoCivil/List");

                if (responsePaci.IsSuccessStatusCode)
                {
                    var jsonResponse = await responsePaci.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    //string message = (string)jsonObj["message"];

                    //ViewBag.message = message;

                    ViewBag.paci_Id = new SelectList(jsonObj["data"].ToList(), "paci_Id", "paci_NombreCompleto");
                }

                //if (responseEstado.IsSuccessStatusCode)
                //{
                //    var jsonResponse = await responseEstado.Content.ReadAsStringAsync();
                //    JObject jsonObj = JObject.Parse(jsonResponse);
                //    string message = (string)jsonObj["message"];

                //    ViewBag.message = message;

                //    ViewBag.estacivi_Id = new SelectList(jsonObj["data"].ToList(), "estacivi_Id", "estacivi_Nombre");
                //}

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ConsultaViewModel item)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(_baseurl + "api/Consultas/Insert", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    var responsePaci = await httpClient.GetAsync(_baseurl + "api/Paciente/List");

                    if (responsePaci.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responsePaci.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);
                        string message = (string)jsonObj["message"];

                        ViewBag.message = message;

                        ViewBag.paci_Id = new SelectList(jsonObj["data"].ToList(), "paci_Id", "paci_Nombre");
                    }
                    return View(item);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ConsultaViewModel consulta = new ConsultaViewModel();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Consultas/FindID?id=" + id);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    consulta = JsonConvert.DeserializeObject<ConsultaViewModel>(content);
                    return View(consulta);
                }
                else
                {
                    return View(consulta);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ConsultaViewModel item, int id)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync(_baseurl + "api/Consultas/Edit?id=" + id, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, errorContent);
                    return View(item);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Costo(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Consultas/Costo?id=" + id);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();

                    return Json(jsonResponse);
                }
                else
                {
                    return Json(id);
                }
            }
        }
    }
}
