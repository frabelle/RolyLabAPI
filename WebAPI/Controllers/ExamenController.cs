using Aplicacion.Examen;
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
    public class ExamenController : MiControllerBase
    {
        public async Task<ActionResult<List<TblExamenes>>> Get()
        {
            return await Mediator.Send(new ExamenConsulta.EjecutaExamen());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblExamenes>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaExamenId.Unico { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<MediatR.Unit>> Crear(NuevoExamen.EjecutaExamen data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarExamen.EjecutaExamen data)
        {
            data.IdExamen = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarExamen.EjecutaExamen { Id = id });
        }
    }
}
