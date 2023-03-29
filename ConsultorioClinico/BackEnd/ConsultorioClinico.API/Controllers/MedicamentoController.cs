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
    public class MedicamentoController : ControllerBase
    {
        private readonly ConsService _consService;

        public MedicamentoController(ConsService consService)
        {
            _consService = consService;
        }

        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _consService.ListaMedicamentos();
            return Ok(list);
        }
    }
}
