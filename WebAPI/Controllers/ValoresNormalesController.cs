using Aplicacion.ValoresNormales;
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
    public class ValoresNormalesController : MiControllerBase
    {
        public async Task<ActionResult<List<TblCatValoresNormales>>> Get()
        {
            return await Mediator.Send(new ValoresNormalesConsulta.EjecutaValoresNormales());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatValoresNormales>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaValoresNormalesId.ValoresNormalesUnico { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Unit>> Crear(NuevoValoresNormales.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarValoresNormales.Ejecuta data)
        {
            data.IdValoresNormales = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarValoresNormales.Ejecuta { IdValoresNormales = id });
        }
    }
}
