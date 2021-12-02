using Dominio.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Aplicacion.TipoResultado;
using MediatR;

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

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatTipoResultado>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaTipoResultado.TipoTipoResultadoUnico { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(NuevoTipoResultado.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarTipoResultado.Ejecuta data)
        {
            data.IdTipoResultado = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarTipoResultado.Ejecuta { Id = id });
        }
    }
}
