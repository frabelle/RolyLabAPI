using Aplicacion.Examen;
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
    public class ExamenController : MiControllerBase
    {
        public async Task<ActionResult<List<TblExamenes>>> Get()
        {
            return await Mediator.Send(new ExamenConsulta.EjecutaExamen());
        }
    }
}
