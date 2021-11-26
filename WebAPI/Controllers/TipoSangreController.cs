using Aplicacion.TipoSangre;
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
    public class TipoSangreController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatTipoSangre>>> Get()
        {
            return await Mediator.Send(new TSangreConsulta.EjecutaTipoSangre());
        }
    }
}
