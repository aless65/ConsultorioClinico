using AutoMapper;
using Consultorio.API.Models;
using Consultorio.BussinesLogic.Services;
using ConsultorioClinico.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PantallaPorRolController : Controller
    {
        private readonly AcceService _acceService;
        private readonly IMapper _mapper;

        public PantallaPorRolController(AcceService acceService, IMapper mapper)
        {
            _acceService = acceService;
            _mapper = mapper;
        }

        [HttpGet("Permisos")]
        public int Permisos(int role_Id, int pant_Id, bool esAdmin)
        {
            var permiso = _acceService.Permisos(role_Id, pant_Id, esAdmin);
            return permiso;
        }

        [HttpPost("Insert")]
        public IActionResult Insert(PantallaPorRolViewModel item)
        {
            var mapeado = _mapper.Map<tbPantallasPorRoles>(item);

            var insert = _acceService.InsertarPantallasPorRoles(mapeado);
            return Ok(insert);
        }

        [HttpPut("Delete")]
        public IActionResult Delete(PantallaPorRolViewModel item)
        {
            var mapeado = _mapper.Map<tbPantallasPorRoles>(item);

            var delete = _acceService.EliminarPantallasPorRoles(mapeado);
            return Ok(delete);
        }
    }
}
