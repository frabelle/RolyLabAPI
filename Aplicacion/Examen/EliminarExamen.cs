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

namespace Aplicacion.Examen
{
    public class EliminarExamen
    {
        public class EjecutaExamen : IRequest
        {
            public Guid Id { get; set; }
        }
        public class ManejadorExamen : IRequestHandler<EjecutaExamen>
        {
            private readonly netLisContext _context;
            public ManejadorExamen(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaExamen request, CancellationToken cancellationToken)
            {
                var Examen = await _context.TblExamenes.FindAsync(request.Id);
                if (Examen == null)
                {
                    throw new Exception("No se encontro");
                        //ManejadorExcepcion(HttpStatusCode.NotFound, new { Examenes = "No se encontró el curso"});
                }
                _context.Remove(Examen);

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
