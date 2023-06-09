﻿using Consultorio.WebUI.Models;
using Microsoft.AspNetCore.Http;
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

            ViewBag.pant_Id = 6;
            ViewBag.role_Id = HttpContext.Session.GetInt32("role_Id");
            ViewBag.user_EsAdmin = HttpContext.Session.GetString("user_EsAdmin");

            if (TempData["script"] is string script)
            {
                TempData.Remove("script");
                ViewBag.Script = script;
            }

            using (var httpClient = new HttpClient())
            {
                var permiso = await httpClient.GetAsync(_baseurl + $"api/PantallaPorRol/Permisos?role_Id={ViewBag.role_Id}&pant_Id={ViewBag.pant_Id}&esAdmin={Convert.ToBoolean(ViewBag.user_EsAdmin)}'");
                var jsonResponsePermiso = await permiso.Content.ReadAsStringAsync();
                JObject jsonObjPermiso = JObject.Parse(jsonResponsePermiso);

                if (jsonObjPermiso.ToString() == "0")
                {
                    return RedirectToAction("Index", "Home");
                }

                var response = await httpClient.GetAsync(_baseurl + "api/Cargo/List");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];

                    ViewBag.message = message;

                    listado = JsonConvert.DeserializeObject<List<CargoViewModel>>(jsonArray.ToString());
                }
                return View(listado);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CargoViewModel item)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(_baseurl + "api/Cargo/Insert", content);

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
                    return View(item);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CargoViewModel cargo = new CargoViewModel();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Cargo/FindID?id=" + id);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    cargo = JsonConvert.DeserializeObject<CargoViewModel>(content);
                    return View(cargo);
                }
                else
                {
                    return View(cargo);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CargoViewModel item, int id)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync(_baseurl + "api/Cargo/Edit?id=" + id, content);

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
                        string script = "MostrarMensajeWarning('" + ViewBag.message + "'); $('#Edit').click();";
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
                    return View(item);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsync(_baseurl + "api/Cargo/Delete?id=" + id, null);

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
                        string script = "MostrarMensajeWarning('" + ViewBag.message + "');";
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
                    return RedirectToAction("Index");
                }
            }
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            List<CargoViewModel> listado = new List<CargoViewModel>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Cargo/List");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];

                    ViewBag.message = message;

                    listado = JsonConvert.DeserializeObject<List<CargoViewModel>>(jsonArray.ToString());
                }
                return View(listado.Where(X => X.carg_Id == id));
            }
        }
    }
}
