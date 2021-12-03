using Aplicacion.Nacionalidad;
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
    public class NacionalidadController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatNacionalidad>>> Get()
        {
            return await Mediator.Send(new NacionalidadConsulta.EjecutaNacionalidad());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatNacionalidad>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaNacionalidadId.Unico { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<MediatR.Unit>> Crear(NuevoNacionalidad.EjecutaNacionalidad data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarNacionalidad.EjecutaNacionalidad data)
        {
            data.IdNacionalidad = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarNacionalidad.EjecutaNacionalidad { Id = id });
        }
    }
}
