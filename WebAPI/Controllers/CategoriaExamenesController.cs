using Aplicacion.CatogoriaExamenes;
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
    public class CategoriaExamenesController : MiControllerBase
    {
        public async Task<ActionResult<List<TblCatCategoriaExamenes>>> Get()
        {
            return await Mediator.Send(new CategoriaExamenConsulta.EjecutaCategoriaExamen());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatCategoriaExamenes>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaCategoriaExamenesId.Unico { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Unit>> Crear(NuevoCategoriaExamenes.EjecutaCategoriaExamenes data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarCategoriaExamenes.EjecutaCategoriaExamenes data)
        {
            data.IdCategoriaExamenes = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarCategoriaExamenes.EjecutaCategoriaExamenes { Id = id });
        }
    }
}
