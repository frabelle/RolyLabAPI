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

namespace Aplicacion.Pais
{
    public class EliminarPais
    {
        public class EjecutaPais : IRequest
        {
            public Guid Id { get; set; }
        }
        public class ManejadorPais : IRequestHandler<EjecutaPais>
        {
            private readonly netLisContext _context;
            public ManejadorPais(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaPais request, CancellationToken cancellationToken)
            {
                var Pais = await _context.TblCatPais.FindAsync(request.Id);
                if (Pais == null)
                {
                    throw new Exception("No se encontro");
                        //ManejadorExcepcion(HttpStatusCode.NotFound, new { Paises = "No se encontró el curso"});
                }
                _context.Remove(Pais);

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
