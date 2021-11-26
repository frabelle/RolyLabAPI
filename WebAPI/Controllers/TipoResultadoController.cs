using Dominio.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Aplicacion.TipoResultado;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoResultadoController : MiControllerBase
    {
        public async Task<ActionResult<List<TblCatTipoResultado>>> Get()
        {
            return await Mediator.Send(new TipoResultadoConsulta.EjecutaTipoResultado());
        }
    }
}
