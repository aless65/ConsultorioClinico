using Consultorio.BussinesLogic.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PantallaController : Controller
    {
        private readonly AcceService _acceService;
        public PantallaController(AcceService acceService)
        {
            _acceService = acceService;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _acceService.ListaPantallas();
            return Ok(list);
        }

        [HttpGet("Find")]
        public IActionResult PantallaDeRol(int id)
        {
            var list = _acceService.ListaPantallasDeRol(id);
            return Ok(list);
        }

        [HttpGet("PantallaMenu")]
        public IActionResult PantallasMenu(int role_Id, bool esAdmin)
        {
            var list = _acceService.PantallasMenu(role_Id, esAdmin);
            return Ok(list);
        }
    }
}
