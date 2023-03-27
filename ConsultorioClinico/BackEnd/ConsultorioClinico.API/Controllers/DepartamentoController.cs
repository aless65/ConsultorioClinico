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
    public class DepartamentoController : ControllerBase
    {
        private readonly GralService _gralService;
        private readonly IMapper _mapper;

        public DepartamentoController(GralService maquService, IMapper mapper)
        {
            _gralService = maquService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _gralService.ListaDepartamentos();
            return Ok(list);
        }

        [HttpPost("Insert")]
        public IActionResult Create(VW_tbDepartamentos item)
        {
            var insert = _gralService.InsertarDepartamentos(item);
            return Ok(insert);
        }

        [HttpGet("ListMunicipios")]
        public IActionResult ListMunicipios(string id)
        {
            var listar = _gralService.ListarMunicipios(id);
            return Ok(listar);
        }

        //[HttpPut("Editar")]
        //public IActionResult Update(VW_tbDepartamentos item)
        //{
        //    var edit = _gralService.EditarDepartamentos(item);
        //    return Ok(edit);
        //}
    }
}
