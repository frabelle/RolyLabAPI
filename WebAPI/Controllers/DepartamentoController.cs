using Aplicacion.Departamentos;
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
    public class DepartamentoController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatDepartamento>>> Get()
        {
            return await Mediator.Send(new DepartamentoConsulta.EjecutaDepartamento());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatDepartamento>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaDepartamentoId.Unico { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Unit>> Crear(NuevoDepartamento.EjecutaDepartamento data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarDepartamento.EjecutaDepartamento data)
        {
            data.IdDepartamento = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarDepartamento.EjecutaDepartamento { Id = id });
        }
    }
}
