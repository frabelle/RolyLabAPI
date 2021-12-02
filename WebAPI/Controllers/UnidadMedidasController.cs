using Aplicacion.UnidadMedida;
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
    public class UnidadMedidasController : MiControllerBase
    {
        public async Task<ActionResult<List<TblCatUnidadMedida>>> Get()
        {
            return await Mediator.Send(new UnidadMedidaConsulta.EjecutaUnidadMedida());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatUnidadMedida>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaUnidadMedida.UnidadMedidaUnica { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Crear(NuevoUnidadMedida.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarUnidadMedida.Ejecuta data)
        {
            data.IdUnidadMedidas = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarUnidadMedida.Ejecuta { IdUnidadMedidas = id });
        }
    }
}
