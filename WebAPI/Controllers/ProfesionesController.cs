using Aplicacion.Profesiones;
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
    public class ProfesionesController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatProfesiones>>> Get()
        {
            return await Mediator.Send(new ProfesionesConsulta.EjecutaProfesiones());
        }
    }
}
