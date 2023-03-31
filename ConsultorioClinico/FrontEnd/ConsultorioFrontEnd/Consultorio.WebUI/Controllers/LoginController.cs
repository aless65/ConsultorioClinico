using Consultorio.WebUI.Models;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Login(string user, string contrasena)
        {
            using (var httpClient = new HttpClient())
            {
                List<UsuariosViewModel> listado = new List<UsuariosViewModel>();
                var response = await httpClient.GetAsync(_baseurl + $"api/Usuarios/Login?user={user}&contrasena={contrasena}");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    listado = JsonConvert.DeserializeObject<List<UsuariosViewModel>>(jsonResponse);
                    if (listado.Count > 0)
                    {
                        int user_Id = listado[0].user_Id;
                        string user_NombreUsuario = listado[0].user_NombreUsuario;
                        bool user_EsAdmin = (bool)listado[0].user_EsAdmin;
                        int empe_ID = listado[0].empe_Id;
                        string empe_NombreCompleto = listado[0].empe_NombreCompleto;
                        int role_ID = listado[0].role_Id;

                        HttpContext.Session.SetInt32("user_Id", user_Id);
                        HttpContext.Session.SetString("user_NombreUsuario", user_NombreUsuario);
                        HttpContext.Session.SetString("user_EsAdmin", user_EsAdmin.ToString());
                        HttpContext.Session.SetInt32("empe_Id", empe_ID);
                        HttpContext.Session.SetString("empe_NombreCompleto", empe_NombreCompleto);
                        HttpContext.Session.SetInt32("role_Id", role_ID);
                        ViewBag.empe_NombreCompleto = HttpContext.Session.GetString("empe_NombreCompleto");

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("user_Id", 0);
                        return View("Index");
                    }
                }
                else
                {
                    return View();
                }
            }
        }
    }
}
