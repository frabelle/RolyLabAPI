using Aplicacion.AreasServ;
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
    public class AreaServiciosController : MiControllerBase
    {
        public async Task<ActionResult<List<TblCatAreasServ>>> Get()
        {
            return await Mediator.Send(new AreaServConsulta.EjecutaAreaServ());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatAreasServ>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaAreaServId.Unico { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Unit>> Crear(NuevoAreaServ.EjecutaAreaServ data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarAreaServ.EjecutaAreaServ data)
        {
            data.IdAreaServ = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarAreaServ.EjecutaAreaServ { Id = id });
        }


    }
}
