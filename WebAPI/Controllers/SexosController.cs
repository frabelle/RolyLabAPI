using Aplicacion.Sexos;
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
    public class SexosController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatSexos>>> Get()
        {
            return await Mediator.Send(new SexosConsulta.EjecutaSexos());
        }
    }
}
