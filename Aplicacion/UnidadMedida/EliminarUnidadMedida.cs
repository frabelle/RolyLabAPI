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

namespace Aplicacion.UnidadMedida
{
    public class EliminarUnidadMedida
    {
        public class Ejecuta : IRequest
        {
            public Guid IdUnidadMedidas { get; set; }
            public string UnidadMedida { get; set; }
            public int? Estado { get; set; }
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
                var unidadMedida = await _context.TblCatUnidadMedidas.FindAsync(request.IdUnidadMedidas);
                if (unidadMedida == null)
                {
                    throw new Exception("No se encontró la unidad de medida");
                        //ManejadorExcepcion(HttpStatusCode.NotFound, new { perfiles = "No se encontró el curso"});
                }
                _context.Remove(unidadMedida);

                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar la unidad de medida");
            }
        }
    }
}
