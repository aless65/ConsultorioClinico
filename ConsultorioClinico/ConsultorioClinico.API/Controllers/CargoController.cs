using AutoMapper;
using Consultorio.BussinesLogic.Services;
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
    }
}
