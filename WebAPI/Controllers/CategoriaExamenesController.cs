using Aplicacion.CatogoriaExamenes;
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
    public class CategoriaExamenesController : MiControllerBase
    {
        public async Task<ActionResult<List<TblCatCategoriaExamenes>>> Get()
        {
            return await Mediator.Send(new CategoriaExamenConsulta.EjecutaCategoriaExamen());
        }
    }
}
