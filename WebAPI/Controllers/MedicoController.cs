using Aplicacion.Medicos;
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
    public class MedicosController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblMedico>>> Get()
        {
            return await Mediator.Send(new MedicosConsulta.EjecutaMedicos());
        }
    }
}
