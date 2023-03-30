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
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AcceService _acceService;
        private readonly IMapper _mapper;

        public UsuariosController(AcceService consService, IMapper mapper)
        {
            _acceService = consService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _acceService.ListaUsuarios();
            return Ok(list);
        }

        [HttpPost("Insert")]
        public IActionResult Insert(VW_tbUsuarios_View item)
        {
            var insert = _acceService.InsertarUsuarios(item);
            return Ok(insert);
        }

        [HttpPut("Edit")]
        public IActionResult Update(VW_tbUsuarios_View item, int id)
        {
            var update = _acceService.EditarUsuarios(item, id);
            return Ok(update);
        }

        [HttpPut("Delete")]
        public IActionResult Delete(int id)
        {
            var delete = _acceService.EliminarUsuarios(id);
            return Ok(delete);
        }
    }
}
