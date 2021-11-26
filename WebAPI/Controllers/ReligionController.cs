using Aplicacion.Religion;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReligionController : MiControllerBase
    {
        public async Task<ActionResult<List<TblCatReligion>>> Get()
        {
            return await Mediator.Send(new ReligionConsulta.EjecutaReligion());
        }
    }
}
