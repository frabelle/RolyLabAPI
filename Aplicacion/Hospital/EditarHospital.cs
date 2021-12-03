using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Hospital
{
    public class EditarHospital
    {
        public class EjecutaHospital : IRequest
        {
            public Guid IdHospital { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }
        }

        public class EjecutaValidacionHospital : AbstractValidator<EjecutaHospital>
        {
            public EjecutaValidacionHospital()
            {
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
              
               
            }
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
                var Hospital = await _context.TblCatHospitals.FindAsync(request.IdHospital);
                if (Hospital == null)
                {
                    throw new Exception("El Hospital no existe");
                }
               
                Hospital.Descripcion = request.Descripcion ?? Hospital.Descripcion;
                Hospital.Estado = 2; 

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el Hospital");
            }
        }
    }
}
