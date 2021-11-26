using Aplicacion.AreasServ;
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
    public class AreaServiciosController : MiControllerBase
    {
        public async Task<ActionResult<List<TblCatAreasServ>>> Get()
        {
            return await Mediator.Send(new AreaServConsulta.EjecutaAreaServ());
        }
    }
}
