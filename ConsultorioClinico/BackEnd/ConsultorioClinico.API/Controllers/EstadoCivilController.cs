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

    public class EstadoCivilController : ControllerBase
    {
        private readonly GralService _gralService;
        private readonly IMapper _mapper;

        public EstadoCivilController(GralService gralService, IMapper mapper)
        {
            _gralService = gralService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult Index()
        {
            var list = _gralService.ListarEstadosCiviles();
            return Ok(list);
        }
    }
}
