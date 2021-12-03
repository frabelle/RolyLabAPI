using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.EstadoCivil
{
    public class EditarEstadoCivil
    {
        public class EjecutaEstadoCivil : IRequest
        {
            public Guid IdEstadoCivil { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }
        }

        public class EjecutaValidacionEstadoCivil : AbstractValidator<EjecutaEstadoCivil>
        {
            public EjecutaValidacionEstadoCivil()
            {
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
              
               
            }
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
                var EstadoCivil = await _context.TblCatEstadoCivils.FindAsync(request.IdEstadoCivil);
                if (EstadoCivil == null)
                {
                    throw new Exception("El EstadoCivil no existe");
                }
               
                EstadoCivil.Descripcion = request.Descripcion ?? EstadoCivil.Descripcion;
                EstadoCivil.Estado = 2; 

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el EstadoCivil");
            }
        }
    }
}
