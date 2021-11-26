using Dominio.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.PerfilExamen;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilExamenController : MiControllerBase
    {
        public async Task<ActionResult<List<TblCatPerfilesExamenes>>> Get()
        {
            return await Mediator.Send(new PerfilExamenConsulta.EjecutaPerfilExamen());
        }
    }
}
