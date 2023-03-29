using Consultorio.WebUI.Models;
using Microsoft.AspNetCore.Http;
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
    public class FacturaController : Controller
    {
        private static string _baseurl;

        public FacturaController()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseurl = builder.GetSection("ApiSettings:BaseUrl").Value;
        }

        // GET: FacturaController
        public async Task<IActionResult> Index()
        {
            List<FacturaViewModel> listado = new List<FacturaViewModel>();

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(_baseurl + "api/Factura/List");

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());

                    listado = JsonConvert.DeserializeObject<List<FacturaViewModel>>(jsonArray.ToString());
                }

                return View(listado);
            }
        }

        // GET: FacturaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            using (var httpClient = new HttpClient())
            {
                var responsePaci = await httpClient.GetAsync(_baseurl + "api/Paciente/List");
                var responseEmpe = await httpClient.GetAsync(_baseurl + "api/Empleado/List");
                var responseMeto = await httpClient.GetAsync(_baseurl + "api/Metodo/List");
                var detalles = await httpClient.GetAsync(_baseurl + "api/Factura/List");

                if (responsePaci.IsSuccessStatusCode)
                {
                    var jsonResponse = await responsePaci.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);

                    ViewBag.paci_Id = new SelectList(jsonObj["data"].ToList(), "paci_Id", "paci_NombreCompleto");
                }

                if (responseEmpe.IsSuccessStatusCode)
                {
                    var jsonResponse = await responseEmpe.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);

                    ViewBag.empe_Id = new SelectList(jsonObj["data"].ToList(), "empe_Id", "empe_NombreCompleto");
                }

                if (responseMeto.IsSuccessStatusCode)
                {
                    var jsonResponse = await responseMeto.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);

                    ViewBag.meto_Id = new SelectList(jsonObj["data"].ToList(), "meto_Id", "meto_Nombre");
                }

                if (detalles.IsSuccessStatusCode)
                {
                    //FacturasYDetallesViewModel paraId = new FacturasYDetallesViewModel();

                    var jsonResponse = await detalles.Content.ReadAsStringAsync();
                    JObject jsonObj = JObject.Parse(jsonResponse);
                    JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());

                    var listado = JsonConvert.DeserializeObject<List<FacturasYDetallesViewModel>>(jsonArray.ToString());

                    ViewBag.detalles = listado.Where(X => X.fact_Id == ViewBag.fact_Id);
                }

                ViewBag.medi_Id = null;
                ViewBag.cons_Id = null;

                return View();

            }
        }

        // POST: FacturaController/Create
        [HttpPost]
        public async Task<IActionResult> Create(FacturasYDetallesViewModel item)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(_baseurl + "api/Factura/Insert", content);

                var jsonResponseMain = await response.Content.ReadAsStringAsync();
                JObject jsonObjMain = JObject.Parse(jsonResponseMain);

                if (response.IsSuccessStatusCode)
                {
                    var responsePaci = await httpClient.GetAsync(_baseurl + "api/Paciente/List");
                    var responseEmpe = await httpClient.GetAsync(_baseurl + "api/Empleado/List");
                    var responseMeto = await httpClient.GetAsync(_baseurl + "api/Metodo/List");
                    var responseMedi = await httpClient.GetAsync(_baseurl + "api/Medicamento/List");
                    var responseCons = await httpClient.GetAsync(_baseurl + "api/Consultas/List");
                    var detalles = await httpClient.GetAsync(_baseurl + "api/Factura/List");

                    if (responsePaci.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responsePaci.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.paci_Id = new SelectList(jsonObj["data"].ToList(), "paci_Id", "paci_NombreCompleto");
                    }

                    if (responseEmpe.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseEmpe.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.empe_Id = new SelectList(jsonObj["data"].ToList(), "empe_Id", "empe_NombreCompleto");
                    }

                    if (responseMeto.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseMeto.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.meto_Id = new SelectList(jsonObj["data"].ToList(), "meto_Id", "meto_Nombre");
                    }

                    if (responseMedi.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseMedi.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.medi_Id = new SelectList(jsonObj["data"].ToList(), "medi_Id", "medi_Nombre");
                    }

                    if (responseCons.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseCons.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.cons_Id = new SelectList(jsonObj["data"].ToList(), "cons_Id", "cons_DropDown");
                    }

                    item.fact_Id = int.Parse(jsonObjMain["message"].ToString());
                    ViewBag.fact_Id = item.fact_Id;

                    if (detalles.IsSuccessStatusCode)
                    {
                        var jsonResponse = await detalles.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);
                        JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());

                        var listado = JsonConvert.DeserializeObject<List<FacturasYDetallesViewModel>>(jsonArray.ToString());

                        ViewBag.detalles = listado.Where(X => X.fact_Id == item.fact_Id);
                    }

                    string script = "$('#paci_Id').prop('disabled', true); " +
                                    "$('#empe_Id').prop('disabled', true); " +
                                    "$('#meto_Id').prop('disabled', true); " +
                                    "$('#subirFactura').prop('disabled', true);";
                    TempData["script"] = script;

                    return View(item);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDetalle(FacturasYDetallesViewModel item)
        {
            using (var httpClient = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(_baseurl + "api/Factura/InsertDetalles", content);

                var jsonResponseMain = await response.Content.ReadAsStringAsync();
                JObject jsonObjMain = JObject.Parse(jsonResponseMain);

                if (response.IsSuccessStatusCode)
                {
                    var responsePaci = await httpClient.GetAsync(_baseurl + "api/Paciente/List");
                    var responseEmpe = await httpClient.GetAsync(_baseurl + "api/Empleado/List");
                    var responseMeto = await httpClient.GetAsync(_baseurl + "api/Metodo/List");
                    var responseMedi = await httpClient.GetAsync(_baseurl + "api/Medicamento/List");
                    var responseCons = await httpClient.GetAsync(_baseurl + "api/Consultas/List");
                    var detalles = await httpClient.GetAsync(_baseurl + "api/Factura/List");

                    if (responsePaci.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responsePaci.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.paci_Id = new SelectList(jsonObj["data"].ToList(), "paci_Id", "paci_NombreCompleto");
                    }

                    if (responseEmpe.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseEmpe.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.empe_Id = new SelectList(jsonObj["data"].ToList(), "empe_Id", "empe_NombreCompleto");
                    }

                    if (responseMeto.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseMeto.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.meto_Id = new SelectList(jsonObj["data"].ToList(), "meto_Id", "meto_Nombre");
                    }

                    if (responseMedi.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseMedi.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.medi_Id = new SelectList(jsonObj["data"].ToList(), "medi_Id", "medi_Nombre");
                    }

                    if (responseCons.IsSuccessStatusCode)
                    {
                        var jsonResponse = await responseCons.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);

                        ViewBag.cons_Id = new SelectList(jsonObj["data"].ToList(), "cons_Id", "cons_DropDown");
                    }

                    if (detalles.IsSuccessStatusCode)
                    {
                        var jsonResponse = await detalles.Content.ReadAsStringAsync();
                        JObject jsonObj = JObject.Parse(jsonResponse);
                        JArray jsonArray = JArray.Parse(jsonObj["data"].ToString());

                        var listado = JsonConvert.DeserializeObject<List<FacturasYDetallesViewModel>>(jsonArray.ToString());

                        ViewBag.detalles = listado.Where(X => X.fact_Id == item.fact_Id);
                    }

                    item.fact_Id = item.fact_Id;

                    string script = "$('#paci_Id').prop('disabled', true); " +
                                    "$('#empe_Id').prop('disabled', true); " +
                                    "$('#meto_Id').prop('disabled', true); " +
                                    "$('#subirFactura').prop('disabled', true);";
                    TempData["script"] = script;


                    return View("Create", item);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        // GET: FacturaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
