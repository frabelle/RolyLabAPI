using Aplicacion.Sexos;
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
    public class SexosController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatSexos>>> Get()
        {
            return await Mediator.Send(new SexosConsulta.EjecutaSexos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatSexos>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaSexoId.SexoUnico { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Unit>> Crear(NuevoSexo.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarSexo.Ejecuta data)
        {
            data.IdSexo = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarSexo.Ejecuta { Id = id });
        }
    }
}
