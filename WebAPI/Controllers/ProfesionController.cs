using Aplicacion.Profesion;
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
    public class ProfesionController : MiControllerBase
    {
        public async Task<ActionResult<List<TblCatProfesiones>>> Get()
        {
            return await Mediator.Send(new ProfesionConsulta.EjecutaProfesion());
        }
    }
}
