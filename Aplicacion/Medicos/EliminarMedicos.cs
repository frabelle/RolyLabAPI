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

namespace Aplicacion.Medicos
{
    public class EliminarMedico
    {
        public class EjecutaMedico : IRequest
        {
            public Guid Id { get; set; }
        }
        public class ManejadorMedico : IRequestHandler<EjecutaMedico>
        {
            private readonly netLisContext _context;
            public ManejadorMedico(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaMedico request, CancellationToken cancellationToken)
            {
                var Medicos = await _context.TblMedicos.FindAsync(request.Id);
                if (Medicos == null)
                {
                    throw new Exception();
                        //ManejadorExcepcion(HttpStatusCode.NotFound, new { Medicoes = "No se encontró el curso"});
                }
                _context.Remove(Medicos);

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
