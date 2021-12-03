using Aplicacion.Hospital;
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
    public class HospitalController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatHospital>>> Get()
        {
            return await Mediator.Send(new HospitalConsulta.EjecutaHospital());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatHospital>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaHospitalId.Unico { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<MediatR.Unit>> Crear(NuevoHospital.EjecutaHospital data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarHospital.EjecutaHospital data)
        {
            data.IdHospital = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarHospital.EjecutaHospital { Id = id });
        }
    }
}
