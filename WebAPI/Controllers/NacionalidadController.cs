using Aplicacion.Nacionalidad;
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
    public class NacionalidadController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatNacionalidad>>> Get()
        {
            return await Mediator.Send(new NacionalidadConsulta.EjecutaNacionalidad());
        }
    }
}
