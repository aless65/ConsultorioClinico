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
    public class EmpleadoController : Controller
    {
        private static string _baseurl;

        public EmpleadoController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;
        }

        public async Task<IActionResult> Index()
        {

            List<EmpleadoViewModel> listado = new List<EmpleadoViewModel>();

            if (TempData["script"] is string script)
            {
                TempData.Remove("script");
                ViewBag.Script = script;
            }

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Empleado/List");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];

                    ViewBag.message = message;

                    listado = JsonConvert.DeserializeObject<List<EmpleadoViewModel>>(jsonArray.ToString());
                }
                return View(listado);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            using (var httpClient = new HttpClient())
            {
                var responseDepa = await httpClient.GetAsync(_baseurl + "api/Departamento/List");
                var responseEstado = await httpClient.GetAsync(_baseurl + "api/EstadoCivil/List");
                var responseCargo = await httpClient.GetAsync(_baseurl + "api/Cargo/List");
                var responseClinica = await httpClient.GetAsync(_baseurl + "api/Clinica/List");

                if (responseDepa.IsSuccessStatusCode)
                {
                    var jsonResponse = await responseDepa.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    string message = (string)jsonObj["message"];

                    ViewBag.message = message;

                    ViewBag.depa_Id = new SelectList(jsonObj["data"].ToList(), "depa_Id", "depa_Nombre");
                }

                if (responseEstado.IsSuccessStatusCode)
                {
                    var jsonResponse = await responseEstado.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    string message = (string)jsonObj["message"];

                    ViewBag.message = message;

                    ViewBag.estacivi_Id = new SelectList(jsonObj["data"].ToList(), "estacivi_Id", "estacivi_Nombre");
                }

                if (responseCargo.IsSuccessStatusCode)
                {
                    var jsonResponse = await responseCargo.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    string message = (string)jsonObj["message"];

                    ViewBag.message = message;

                    ViewBag.carg_Id = new SelectList(jsonObj["data"].ToList(), "carg_Id", "carg_Nombre");
                }

                if (responseClinica.IsSuccessStatusCode)
                {
                    var jsonResponse = await responseClinica.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    string message = (string)jsonObj["message"];

                    ViewBag.message = message;

                    ViewBag.clin_Id = new SelectList(jsonObj["data"].ToList(), "clin_Id", "clin_Nombre");
                }

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmpleadoViewModel item)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(_baseurl + "api/Empleado/Insert", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);

                    ViewBag.message = jsonObj["message"];

                    if (jsonObj["code"].ToString() == "200")
                    {
                        string script = "MostrarMensajeSuccess('" + ViewBag.message + "');";
                        TempData["script"] = script;
                    }
                    else if (jsonObj["code"].ToString() == "409")
                    {
                        string script = "MostrarMensajeWarning('" + ViewBag.message + "'); $('#New').click();";
                        TempData["script"] = script;
                    }
                    else
                    {
                        string script = "MostrarMensajeDanger('" + ViewBag.message + "');";
                        TempData["script"] = script;
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    var responseDepa = await httpClient.GetAsync(_baseurl + "api/Departamento/List");
                    var responseEstado = await httpClient.GetAsync(_baseurl + "api/EstadoCivil/List");
                    var responseCargo = await httpClient.GetAsync(_baseurl + "api/Cargo/List");
                    var responseClinica = await httpClient.GetAsync(_baseurl + "api/Clinica/List");


                    if (responseDepa.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseDepa.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.depa_Id = new SelectList(jsonObj["data"].ToList(), "depa_Id", "depa_Nombre");
                    }

                    if (responseEstado.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseEstado.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.estacivi_Id = new SelectList(jsonObj["data"].ToList(), "estacivi_Id", "estacivi_Nombre");
                    }

                    if (responseCargo.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseCargo.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.carg_Id = new SelectList(jsonObj["data"].ToList(), "carg_Id", "carg_Nombre");
                    }

                    if (responseClinica.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseClinica.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.clin_Id = new SelectList(jsonObj["data"].ToList(), "clin_Id", "clin_Nombre");
                    }

                    return View(item);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            EmpleadoViewModel empleado = new EmpleadoViewModel();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Empleado/Find?id=" + id);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JObject jsonObjGet = JObject.Parse(content);
                    empleado = JsonConvert.DeserializeObject<EmpleadoViewModel>(jsonObjGet["data"].ToString());

                    ViewBag.muni_Id = empleado.muni_Id;

                    var responseDepa = await httpClient.GetAsync(_baseurl + "api/Departamento/List");
                    var responseEstado = await httpClient.GetAsync(_baseurl + "api/EstadoCivil/List");
                    var responseCargo = await httpClient.GetAsync(_baseurl + "api/Cargo/List");
                    var responseClinica = await httpClient.GetAsync(_baseurl + "api/Clinica/List");

                    if (responseDepa.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseDepa.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.depa_Id = new SelectList(jsonObj["data"].ToList(), "depa_Id", "depa_Nombre");
                    }

                    if (responseEstado.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseEstado.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.estacivi_Id = new SelectList(jsonObj["data"].ToList(), "estacivi_Id", "estacivi_Nombre");
                    }

                    if (responseCargo.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseCargo.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.carg_Id = new SelectList(jsonObj["data"].ToList(), "carg_Id", "carg_Nombre");
                    }

                    if (responseClinica.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseClinica.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.clin_Id = new SelectList(jsonObj["data"].ToList(), "clin_Id", "clin_Nombre");
                    }

                    return View(empleado);
                }
                else
                {
                    return View(empleado);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmpleadoViewModel item, int id)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync(_baseurl + "api/Empleado/Edit?id=" + id, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);

                    ViewBag.message = jsonObj["message"];

                    if (jsonObj["code"].ToString() == "200")
                    {
                        string script = "MostrarMensajeSuccess('" + ViewBag.message + "');";
                        TempData["script"] = script;

                        return RedirectToAction("Index");
                    }
                    else if (jsonObj["code"].ToString() == "409")
                    {
                        string script = "MostrarMensajeWarning('" + ViewBag.message + "'); $('#New').click();";
                        TempData["script"] = script;

                        return View(item);
                    }
                    else
                    {
                        string script = "MostrarMensajeDanger('" + ViewBag.message + "');";
                        TempData["script"] = script;

                        return View(item);
                    }

                }
                else
                {
                    ViewBag.muni_Id = item.muni_Id;

                    var responseDepa = await httpClient.GetAsync(_baseurl + "api/Departamento/List");
                    var responseEstado = await httpClient.GetAsync(_baseurl + "api/EstadoCivil/List");
                    var responseCargo = await httpClient.GetAsync(_baseurl + "api/Cargo/List");
                    var responseClinica = await httpClient.GetAsync(_baseurl + "api/Clinica/List");

                    if (responseDepa.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseDepa.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.depa_Id = new SelectList(jsonObj["data"].ToList(), "depa_Id", "depa_Nombre");
                    }

                    if (responseEstado.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseEstado.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.estacivi_Id = new SelectList(jsonObj["data"].ToList(), "estacivi_Id", "estacivi_Nombre");
                    }

                    if (responseCargo.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseCargo.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.carg_Id = new SelectList(jsonObj["data"].ToList(), "carg_Id", "carg_Nombre");
                    }

                    if (responseClinica.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseClinica.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.clin_Id = new SelectList(jsonObj["data"].ToList(), "clin_Id", "clin_Nombre");
                    }

                    //var errorContent = await response.Content.ReadAsStringAsync();
                    //ModelState.AddModelError(string.Empty, errorContent);
                    return View(item);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> ListMunicipios(string id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Departamento/ListMunicipios?id=" + id);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());

                    List<object> ddlItems = new List<object>();
                    foreach (JObject jsonObject in jsonArray)
                    {
                        string muni_Id = (string)jsonObject["muni_id"];
                        string muni_Nombre = (string)jsonObject["muni_Nombre"];
                        ddlItems.Add(new { muni_Id = muni_Id, muni_Nombre = muni_Nombre });
                    }

                    return Json(ddlItems);
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsync(_baseurl + "api/Empleado/Delete?id=" + id, null);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    string message = (string)jsonObj["message"];

                    ViewBag.message = message;
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            List<EmpleadoViewModel> listado = new List<EmpleadoViewModel>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Empleado/List");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];

                    ViewBag.message = message;

                    listado = JsonConvert.DeserializeObject<List<EmpleadoViewModel>>(jsonArray.ToString());
                }
                return View(listado.Where(X => X.empe_Id == id));
            }
        }
    }
}
