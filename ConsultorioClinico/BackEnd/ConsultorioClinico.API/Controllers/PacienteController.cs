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
    public class PacienteController : Controller
    {
        private readonly ConsService _consService;

        public PacienteController(ConsService consService)
        {
            _consService = consService;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _consService.ListaPacientes();
            return Ok(list);
        }
    }
}
