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

namespace Aplicacion.Departamentos
{
    public class EliminarDepartamento
    {
        public class EjecutaDepartamento : IRequest
        {
            public Guid Id { get; set; }
        }
        public class ManejadorDepartamento : IRequestHandler<EjecutaDepartamento>
        {
            private readonly netLisContext _context;
            public ManejadorDepartamento(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaDepartamento request, CancellationToken cancellationToken)
            {
                var Departamento = await _context.TblCatDepartamentos.FindAsync(request.Id);
                if (Departamento == null)
                {
                    throw new Exception("No se encontro");
                        //ManejadorExcepcion(HttpStatusCode.NotFound, new { Departamentoes = "No se encontró el curso"});
                }
                _context.Remove(Departamento);

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
