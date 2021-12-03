using Aplicacion.Profesion;
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
    public class ProfesionController : MiControllerBase
    {
        public async Task<ActionResult<List<TblCatProfesiones>>> Get()
        {
            return await Mediator.Send(new ProfesionConsulta.EjecutaProfesion());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatProfesiones>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaProfesion.ProfesionUnica { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Unit>> Crear(NuevaProfesion.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarProfesion.Ejecuta data)
        {
            data.IdProfesiones = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarProfesion.Ejecuta { Id = id });
        }
    }
}
