using Aplicacion.Identificacion;
using Dominio.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentificacionController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatIdentificacion>>> Get()
        {
            return await Mediator.Send(new IdentificacionConsulta.EjecutaIdentificacion());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatIdentificacion>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaIdentificacionId.Unico { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<MediatR.Unit>> Crear(NuevoIdentificacion.EjecutaIdentificacion data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarIdentificacion.EjecutaIdentificacion data)
        {
            data.IdIdentificacion = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarIdentificacion.EjecutaIdentificacion { Id = id });
        }
    }
}
