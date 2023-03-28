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
    public class CargoController : ControllerBase
    {
        private readonly ConsService _consService;
        private readonly IMapper _mapper;

        public CargoController(ConsService consService, IMapper mapper)
        {
            _consService = consService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _consService.ListaCargos();
            return Ok(list);
        }

        [HttpGet("FindID")]
        public VW_tbCargos Find(int id)
        {
            var cargo = _consService.Find(id);
            return cargo;
        }

        [HttpPost("Insert")]
        public IActionResult Insert(VW_tbCargos item)
        {
            var insert = _consService.InsertarCargos(item);
            return Ok(insert);
        }
            
        [HttpPut("Edit")]
        public IActionResult Update(VW_tbCargos item, int id)
        {
            var update = _consService.EditarCargos(item, id);
            return Ok(update);
        }

        [HttpPut("Delete")]
        public IActionResult Delete(int id)
        {
            var delete = _consService.EliminarCargos(id);
            return Ok(delete);
        }
    }
}
