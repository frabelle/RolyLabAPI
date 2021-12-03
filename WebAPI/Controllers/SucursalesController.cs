using Aplicacion.Sucursales;
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
    public class SucursalesController : MiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<TblCatSucursales>>> Get()
        {
            return await Mediator.Send(new SucursalesConsulta.EjecutaSucursales());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatSucursales>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaSucursalId.SucursalUnica { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Unit>> Crear(NuevaSucursal.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarSucursal.Ejecuta data)
        {
            data.IdSucursal = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarSucursal.Ejecuta { Id = id });
        }
    }
}
