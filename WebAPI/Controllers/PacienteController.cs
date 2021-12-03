using Aplicacion.Paciente;
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
    public class PacienteController : MiControllerBase
    {
        public async Task<ActionResult<List<TblPaciente>>> Get()
        {
            return await Mediator.Send(new PacienteConsulta.EjecutaPaciente());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblPaciente>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaPacienteId.Unico { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Unit>> Crear(NuevoPaciente.EjecutaPaciente data)
        {
            return await Mediator.Send(data);
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult<Unit>> Editar(Guid id, EliminarPaciente.Ejecuta data)
        //{
        //    data.IdUnidadMedidas = id;

        //    return await Mediator.Send(data);
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarPaciente.EjecutaPaciente { Id = id });
        }
    }
}
