using Aplicacion.ManejadorError;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Perfil
{
    public class EliminarPerfil
    {
        public class EjecutaPerfil : IRequest
        {
            public Guid Id { get; set; }
        }
        public class ManejadorPerfil : IRequestHandler<EjecutaPerfil>
        {
            private readonly netLisContext _context;
            public ManejadorPerfil(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaPerfil request, CancellationToken cancellationToken)
            {
                var perfiles = await _context.TblCatPerfiles.FindAsync(request.Id);
                if (perfiles == null)
                {
                    throw new Exception();
                        //ManejadorExcepcion(HttpStatusCode.NotFound, new { perfiles = "No se encontró el curso"});
                }
                _context.Remove(perfiles);

                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar el curso");
            }
        }
    }
}
