﻿using Consultorio.BussinesLogic.Services;
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
    public class FacturaController : ControllerBase
    {
        private readonly ConsService _consService;

        public FacturaController(ConsService consService)
        {
            _consService = consService;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _consService.ListaFacturas();
            return Ok(list);
        }

        [HttpGet("ListDetalles")]
        public IActionResult ListDetalles(int id)
        {
            var list = _consService.ListarFacturasDetalles(id);
            return Ok(list);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(VW_tbFacturas_tbFacturasDetalles item)
        {
            var insert = _consService.InsertarFacturas(item);
            return Ok(insert);
        }

        [HttpPost("InsertDetalles")]
        public IActionResult InsertDetalles(VW_tbFacturas_tbFacturasDetalles item)
        {
            var insert = _consService.InsertarFacturasDetalles(item);
            return Ok(insert);
        }

        [HttpPut("DeleteDetalles")]
        public IActionResult DeleteDetalles(int id)
        {
            var delete = _consService.EliminarFacturasDetalles(id);
            return Ok(delete);
        }

        [HttpGet("Find")]
        public IActionResult Find(int id)
        {
            var listado = _consService.FacturaID(id);
            return Ok(listado);
        }
    }
}
