using Aplicacion.EstadoCivil;
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
    public class EstadoCivilController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatEstadoCivil>>> Get()
        {
            return await Mediator.Send(new EstadoCivilConsulta.EjecutaEstadoCivil());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatEstadoCivil>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaEstadoCivilId.Unico { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Unit>> Crear(NuevoEstadoCivil.EjecutaEstadoCivil data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarEstadoCivil.EjecutaEstadoCivil data)
        {
            data.IdEstadoCivil = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarEstadoCivil.EjecutaEstadoCivil { Id = id });
        }
    }
}
