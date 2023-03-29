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
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.WebUI.Controllers
{
    public class RolController : Controller
    {
        private static string _baseurl;

        public RolController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;

        }

        public async Task<IActionResult> Index()
        {
            List<RolViewModel> listado = new List<RolViewModel>();

            if (TempData["script"] is string script)
            {
                TempData.Remove("script");
                ViewBag.Script = script;
            }

            using (var httpClient = new HttpClient())
            {
                ViewBag.rol = TempData["nombreRol"];

                var response = await httpClient.GetAsync(_baseurl + "api/Rol/List");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];

                    ViewBag.message = message;


                    listado = JsonConvert.DeserializeObject<List<RolViewModel>>(jsonArray.ToString());
                }
                return View(listado);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(RolViewModel item)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(_baseurl + "api/Rol/Insert", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);

                    ViewBag.message = jsonObj["message"];

                    //if (jsonObj["code"].ToString() == "200")
                    //{
                    //    string script = "MostrarMensajeSuccess('" + ViewBag.message + "');";
                    //    TempData["script"] = script;
                    //}
                    //else if (jsonObj["code"].ToString() == "409")
                    //{
                    //    string script = "MostrarMensajeWarning('" + ViewBag.message + "'); $('#New').click();";
                    //    TempData["script"] = script;
                    //}
                    //else
                    //{
                    //    string script = "MostrarMensajeDanger('" + ViewBag.message + "');";
                    //    TempData["script"] = script;
                    //}

                    string script = "$('#New').click();" +
                                    "$('#role_Nombre').prop('disabled', true);" +
                                    "$('#enviarCrear').prop('disabled', true);" ;
                    TempData["script"] = script;

                    TempData["nombreRol"] = item.role_Nombre;

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(item);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePantallaPorRol(int pant_Id, string role_Nombre)
        {
            PantallaPorRolViewModel item = new PantallaPorRolViewModel();

            using (var httpClient = new HttpClient())
            {
                item.pant_Id = pant_Id;
                item.role_Nombre = role_Nombre;

                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(_baseurl + "api/PantallaPorRol/Insert", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);

                    if (jsonObj["code"].ToString() == "200")
                    {
                        string script = "MostrarMensajeSuccess('" + ViewBag.message + "');";
                        TempData["script"] = script;
                    }
                }
            }

            return Json(item);
        }

        [HttpPost]
        public async Task<IActionResult> DeletePantallaPorRol(int pant_Id, string role_Nombre)
        {
            PantallaPorRolViewModel item = new PantallaPorRolViewModel();

            using (var httpClient = new HttpClient())
            {
                item.pant_Id = pant_Id;
                item.role_Nombre = role_Nombre;

                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync(_baseurl + "api/PantallaPorRol/Delete", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);

                    if (jsonObj["code"].ToString() == "200")
                    {
                        string script = "MostrarMensajeSuccess('" + ViewBag.message + "');";
                        TempData["script"] = script;
                    }
                }
            }

            return Json(item);
        }
    }
}
