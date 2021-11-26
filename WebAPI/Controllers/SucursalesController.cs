using Aplicacion.Sucursales;
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
    public class SucursalesController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatSucursales>>> Get()
        {
            return await Mediator.Send(new SucursalesConsulta.EjecutaSucursales());
        }
    }
}
