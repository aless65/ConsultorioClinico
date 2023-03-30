using AutoMapper;
using Consultorio.BussinesLogic.Services;
using ConsultorioClinico.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consultorio.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultasController : ControllerBase
    {
        private readonly ConsService _consService;
        private readonly IMapper _mapper;

        public ConsultasController(ConsService consService, IMapper mapper)
        {
            _consService = consService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _consService.ListaConsultas();
            return Ok(list);
        }

        [HttpGet("ListDdl")]
        public IActionResult ListDdl()
        {
            var list = _consService.ListaConsultasDdl();
            return Ok(list);
        }

        [HttpGet("FindID")]
        public VW_tbConsultas Find(int id)
        {
            var cargo = _consService.FindConsultas(id);
            return cargo;
        }

        [HttpPost("Insert")]
        public IActionResult Insert(VW_tbConsultas item)
        {
            var insert = _consService.InsertarConsultas(item);
            return Ok(insert);
        }

        [HttpPut("Edit")]
        public IActionResult Update(VW_tbConsultas item, int id)
        {
            var update = _consService.EditarConsultas(item, id);
            return Ok(update);
        }

        [HttpPut("Delete")]
        public IActionResult Delete(int id)
        {
            var delete = _consService.EliminarConsultas(id);
            return Ok(delete);
        }

        [HttpGet("Costo")]
        public IActionResult Costo(int id)
        {
            var costo = _consService.CostoConsultas(id);
            return Ok(costo);
        }
    }
}
