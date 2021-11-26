using Aplicacion.Departamentos;
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
    public class DepartamentoController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatDepartamento>>> Get()
        {
            return await Mediator.Send(new DepartamentoConsulta.EjecutaDepartamento());
        }
    }
}
