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

namespace Aplicacion.TipoSangre
{
    public class EliminarTipoSangre
    {
        public class Ejecuta : IRequest
        {
            public Guid Id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var tipoSangre = await _context.TblCatTipoSangre.FindAsync(request.Id);
                if (tipoSangre == null)
                {
                    throw new Exception("No se encontró el tipo sangre");
                        //ManejadorExcepcion(HttpStatusCode.NotFound, new { perfiles = "No se encontró el curso"});
                }
                _context.Remove(tipoSangre);

                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar el tipo sangre");
            }
        }
    }
}
