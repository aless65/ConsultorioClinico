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
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly AcceService _acceService;
        private readonly IMapper _mapper;

        public RolController(AcceService consService, IMapper mapper)
        {
            _acceService = consService;
            _mapper = mapper;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _acceService.ListaRoles();
            return Ok(list);
        }
    }
}
