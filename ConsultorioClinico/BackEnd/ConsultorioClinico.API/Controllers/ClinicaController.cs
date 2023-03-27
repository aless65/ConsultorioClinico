using AutoMapper;
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
    public class ClinicaController : ControllerBase
    {
        private readonly ConsService _consService;
        private readonly IMapper _mapper;

        public ClinicaController(ConsService consService, IMapper mapper)
        {
            _consService = consService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _consService.ListaClinicas();
            return Ok(list);
        }
    }
}
