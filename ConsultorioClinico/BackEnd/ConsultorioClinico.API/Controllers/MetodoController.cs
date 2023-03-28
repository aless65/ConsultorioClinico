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
    public class MetodoController : Controller
    {
        private readonly ConsService _consService;

        public MetodoController(ConsService consService)
        {
            _consService = consService;
        }
        [HttpGet("List")]
        public IActionResult List()
        {
            var list = _consService.ListaMetodos();
            return Ok(list);
        }
    }
}
