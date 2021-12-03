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

namespace Aplicacion.Hospital
{
    public class EliminarHospital
    {
        public class EjecutaHospital : IRequest
        {
            public Guid Id { get; set; }
        }
        public class ManejadorHospital : IRequestHandler<EjecutaHospital>
        {
            private readonly netLisContext _context;
            public ManejadorHospital(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaHospital request, CancellationToken cancellationToken)
            {
                var Hospital = await _context.TblCatHospitals.FindAsync(request.Id);
                if (Hospital == null)
                {
                    throw new Exception("No se encontro");
                        //ManejadorExcepcion(HttpStatusCode.NotFound, new { Hospitales = "No se encontró el curso"});
                }
                _context.Remove(Hospital);

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
