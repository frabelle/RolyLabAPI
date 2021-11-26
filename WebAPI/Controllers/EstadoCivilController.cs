﻿using Aplicacion.EstadoCivil;
using Dominio.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoCivilController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatEstadoCivil>>> Get()
        {
            return await Mediator.Send(new EstadoCivilConsulta.EjecutaEstadoCivil());
        }
    }
}
