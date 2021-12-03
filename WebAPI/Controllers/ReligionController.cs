using Aplicacion.Religion;
using Dominio;
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
    public class ReligionController : MiControllerBase
    {
        public async Task<ActionResult<List<TblCatReligion>>> Get()
        {
            return await Mediator.Send(new ReligionConsulta.EjecutaReligion());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatReligion>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaReligionId.ReligionUnica { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Unit>> Crear(NuevaReligion.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarReligion.Ejecuta data)
        {
            data.IdReigion = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarReligion.Ejecuta { Id = id });
        }
    }
}
