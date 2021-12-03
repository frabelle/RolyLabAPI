using Aplicacion.TipoMuestra;
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
    public class TipoMuestrasController : MiControllerBase
    {
        public async Task<ActionResult<List<TblCatTipoMuestra>>> Get()
        {
            return await Mediator.Send(new TipoMuestraConsulta.EjecutaTipoMuestra());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatTipoMuestra>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaTipoMuestraId.TipoMuestraUnica { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Unit>> Crear(NuevoTipoMuestra.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarTipoMuestra.Ejecuta data)
        {
            data.IdTipoMuestra = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarTipoMuestra.Ejecuta { Id = id });
        }
    }
}
