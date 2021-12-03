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

namespace Aplicacion.EstadoCivil
{
    public class EliminarEstadoCivil
    {
        public class EjecutaEstadoCivil : IRequest
        {
            public Guid Id { get; set; }
        }
        public class ManejadorEstadoCivil : IRequestHandler<EjecutaEstadoCivil>
        {
            private readonly netLisContext _context;
            public ManejadorEstadoCivil(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaEstadoCivil request, CancellationToken cancellationToken)
            {
                var EstadoCivil = await _context.TblCatEstadoCivils.FindAsync(request.Id);
                if (EstadoCivil == null)
                {
                    throw new Exception("No se encontro");
                        //ManejadorExcepcion(HttpStatusCode.NotFound, new { EstadoCiviles = "No se encontró el curso"});
                }
                _context.Remove(EstadoCivil);

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
