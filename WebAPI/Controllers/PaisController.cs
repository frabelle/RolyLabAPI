using Aplicacion.Pais;
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
    public class PaisController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatPais>>> Get()
        {
            return await Mediator.Send(new Consulta.Ejecuta());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatPais>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaPaisId.Unico { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<MediatR.Unit>> Crear(NuevoPais.EjecutaPais data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarPais.EjecutaPais data)
        {
            data.IdPais = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarPais.EjecutaPais { Id = id });
        }
    }
}
