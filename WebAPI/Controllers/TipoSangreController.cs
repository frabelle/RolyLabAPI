using Aplicacion.TipoSangre;
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
    public class TipoSangreController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatTipoSangre>>> Get()
        {
            return await Mediator.Send(new TSangreConsulta.EjecutaTipoSangre());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatTipoSangre>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaTipoSangre.TipoSangreUnico { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Unit>> Crear(NuevoTipoSangre.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarTTipoSangre.Ejecuta data)
        {
            data.IdTipoSangre = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarTipoSangre.Ejecuta { Id = id });
        }
    }
}
