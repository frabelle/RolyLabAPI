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

namespace Aplicacion.Identificacion
{
    public class EliminarIdentificacion
    {
        public class EjecutaIdentificacion : IRequest
        {
            public Guid Id { get; set; }
        }
        public class ManejadorIdentificacion : IRequestHandler<EjecutaIdentificacion>
        {
            private readonly netLisContext _context;
            public ManejadorIdentificacion(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaIdentificacion request, CancellationToken cancellationToken)
            {
                var Identificacion = await _context.TblCatIdentificacions.FindAsync(request.Id);
                if (Identificacion == null)
                {
                    throw new Exception("No se encontro");
                        //ManejadorExcepcion(HttpStatusCode.NotFound, new { Identificaciones = "No se encontró el curso"});
                }
                _context.Remove(Identificacion);

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
