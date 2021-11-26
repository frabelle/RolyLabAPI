using Aplicacion.TipoMuestra;
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
    public class TipoMuestrasController : MiControllerBase
    {
        public async Task<ActionResult<List<TblCatTipoMuestra>>> Get()
        {
            return await Mediator.Send(new TipoMuestraConsulta.EjecutaTipoMuestra());
        }
    }
}
