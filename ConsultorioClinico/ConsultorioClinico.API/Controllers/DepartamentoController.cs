﻿using AutoMapper;
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
    }
}