using Aplicacion.Medicos;
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
    public class MedicoController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblMedico>>> Get()
        {
            return await Mediator.Send(new MedicosConsulta.EjecutaMedicos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblMedico>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaMedicoId.Unico { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Unit>> Crear(NuevoMedico.EjecutaMedico data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarMedico.EjecutaMedico data)
        {
            data.IdTblMedico = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarMedico.EjecutaMedico { Id = id });
        }
    }
}
