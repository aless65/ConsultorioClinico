
using AutoMapper;
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
    public class EmpleadoController : ControllerBase
    {
        private readonly ConsService _consService;
        private readonly IMapper _mapper;
        public EmpleadoController(ConsService consService, IMapper mapper)
        {
            _consService = consService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _consService.ListaEmpleados();
            return Ok(list);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(VW_tbEmpleados item)
        {
            var insert = _consService.InsertarEmpleados(item);
            return Ok(insert);
        }

        [HttpPut("Edit")]
        public IActionResult Insert(VW_tbEmpleados item, int id)
        {
            var update = _consService.EditarEmpleados(item, id);
            return Ok(update);
        }

        [HttpPut("Delete")]
        public IActionResult Delete(int id)
        {
            var delete = _consService.EliminarEmpleados(id);
            return Ok(delete);
        }

        [HttpGet("Find")]
        public IActionResult Find(int id)
        {
            var encontrar = _consService.FindEmpleado(id);
            return Ok(encontrar);
        }

        [HttpGet("LoadSex")]
        public IActionResult CargarSexo()
        {
            var listado = _consService.LoadSex();
            return Ok(listado);
        }
    }
}
