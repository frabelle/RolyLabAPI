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

namespace Aplicacion.Nacionalidad
{
    public class EliminarNacionalidad
    {
        public class EjecutaNacionalidad : IRequest
        {
            public Guid Id { get; set; }
        }
        public class ManejadorNacionalidad : IRequestHandler<EjecutaNacionalidad>
        {
            private readonly netLisContext _context;
            public ManejadorNacionalidad(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaNacionalidad request, CancellationToken cancellationToken)
            {
                var Nacionalidad = await _context.TblCatNacionalidads.FindAsync(request.Id);
                if (Nacionalidad == null)
                {
                    throw new Exception("No se encontro");
                        //ManejadorExcepcion(HttpStatusCode.NotFound, new { Nacionalidades = "No se encontró el curso"});
                }
                _context.Remove(Nacionalidad);

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
