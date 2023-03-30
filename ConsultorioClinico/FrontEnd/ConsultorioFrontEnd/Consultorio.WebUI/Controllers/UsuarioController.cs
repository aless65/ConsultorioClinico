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
    public class UsuarioController : Controller
    {
        private static string _baseurl;

        public UsuarioController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;
        }

        public async Task<IActionResult> Index()
        {

            List<UsuariosViewModel> listado = new List<UsuariosViewModel>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Usuarios/List");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];

                    ViewBag.message = message;

                    listado = JsonConvert.DeserializeObject<List<UsuariosViewModel>>(jsonArray.ToString());
                }
                return View(listado);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            using (var httpClient = new HttpClient())
            {
                var responseRol = await httpClient.GetAsync(_baseurl + "api/Rol/List");
                var responseEmp = await httpClient.GetAsync(_baseurl + "api/Empleado/List");

                if (responseRol.IsSuccessStatusCode)
                {
                    var jsonResponse = await responseRol.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    string message = (string)jsonObj["message"];

                    ViewBag.message = message;

                    ViewBag.role_Id = new SelectList(jsonObj["data"].ToList(), "role_Id", "role_Nombre");
                }

                if (responseEmp.IsSuccessStatusCode)
                {
                    var jsonResponse = await responseEmp.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    string message = (string)jsonObj["message"];

                    ViewBag.message = message;

                    ViewBag.empe_Id = new SelectList(jsonObj["data"].ToList(), "empe_Id", "empe_Nombres");
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuariosViewModel item)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(_baseurl + "api/Usuarios/Insert", content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    var responseRol = await httpClient.GetAsync(_baseurl + "api/Rol/List");
                    var responseEmp = await httpClient.GetAsync(_baseurl + "api/Empleado/List");


                    if (responseRol.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseRol.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.role_Id = new SelectList(jsonObj["data"].ToList(), "role_Id", "role_Nombre");
                    }

                    if (responseEmp.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseEmp.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.empe_Id = new SelectList(jsonObj["data"].ToList(), "empe_Id", "empe_Nombres");
                    }

                    return View(item);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            UsuariosViewModel usuario = new UsuariosViewModel();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Usuarios/Find?id=" + id);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    JObject jsonObjGet = JObject.Parse(content);
                    usuario = JsonConvert.DeserializeObject<UsuariosViewModel>(jsonObjGet["data"].ToString());


                    var responseRol = await httpClient.GetAsync(_baseurl + "api/Rol/List");
                    var responseEmp = await httpClient.GetAsync(_baseurl + "api/Empleado/List");

                    if (responseRol.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseRol.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.role_Id = new SelectList(jsonObj["data"].ToList(), "role_Id", "role_Nombre");
                    }

                    if (responseEmp.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseEmp.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.empe_Id = new SelectList(jsonObj["data"].ToList(), "empe_Id", "empe_Nombres");
                    }

                    return View(usuario);
                }
                else
                {
                    return View(usuario);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UsuariosViewModel item, int id)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PutAsync(_baseurl + "api/Usuarios/Edit?id=" + id, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    var responseRol = await httpClient.GetAsync(_baseurl + "api/Rol/List");
                    var responseEmp = await httpClient.GetAsync(_baseurl + "api/Empleado/List");

                    if (responseRol.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseRol.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.role_Id = new SelectList(jsonObj["data"].ToList(), "role_Id", "role_Nombre");
                    }

                    if (responseEmp.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseEmp.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.empe_Id = new SelectList(jsonObj["data"].ToList(), "empe_Id", "empe_Nombres");
                    }

                    //var errorContent = await response.Content.ReadAsStringAsync();
                    //ModelState.AddModelError(string.Empty, errorContent);
                    return View(item);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PutAsync(_baseurl + "api/Usuarios/Delete?id=" + id, null);

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
            List<UsuariosViewModel> listado = new List<UsuariosViewModel>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/usuarios/List");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());
                    string message = (string)jsonObj["message"];

                    ViewBag.message = message;

                    listado = JsonConvert.DeserializeObject<List<UsuariosViewModel>>(jsonArray.ToString());
                }
                return View(listado.Where(X => X.empe_Id == id));
            }
        }
    }
}
