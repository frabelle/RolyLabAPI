using Dominio.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.PerfilExamen;
using MediatR;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilExamenController : MiControllerBase
    {
        public async Task<ActionResult<List<TblCatPerfilesExamenes>>> Get()
        {
            return await Mediator.Send(new PerfilExamenConsulta.EjecutaPerfilExamen());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatPerfilesExamenes>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaPerfilExamenId.PerfilExamenUnico { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(NuevoPerfilExamen.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarPerfilExamen.Ejecuta data)
        {
            data.IdPerfilesExamenes = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarPerfilExamen.Ejecuta { Id = id });
        }
    }
}
