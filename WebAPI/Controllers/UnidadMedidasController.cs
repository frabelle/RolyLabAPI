using Aplicacion.UnidadMedida;
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
    public class UnidadMedidasController : MiControllerBase
    {
        public async Task<ActionResult<List<TblCatUnidadMedida>>> Get()
        {
            return await Mediator.Send(new UnidadMedidaConsulta.EjecutaUnidadMedida());
        }
    }
}
