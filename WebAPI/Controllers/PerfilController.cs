using Dominio.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Perfil;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : MiControllerBase
    {
        public async Task<ActionResult<List<TblCatPerfiles>>> Get()
        {
            return await Mediator.Send(new PerfilConsulta.EjecutaPerfil());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCatPerfiles>> Detalle(Guid id)
        {
            return await Mediator.Send(new ConsultaPerfilId.PerfilUnico { Id = id });
        }

        [HttpPost("Crear")]
        public async Task<ActionResult<Unit>> Crear(NuevoPerfil.EjecutaPerfil data)
        {
            return await Mediator.Send(data);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Editar(Guid id, EditarPerfil.EjecutaPerfil data)
        {
            data.IdPerfiles = id;

            return await Mediator.Send(data);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Eliminar(Guid id)
        {
            return await Mediator.Send(new EliminarPerfil.EjecutaPerfil { Id = id });
        }
    }
}
