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
    }
}
