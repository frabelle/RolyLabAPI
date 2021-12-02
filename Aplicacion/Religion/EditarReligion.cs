using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Religion
{
    public class EditarReligion
    {
        public class Ejecuta : IRequest
        {
            public Guid IdReigion { get; set; }
            public string Descripcion { get; set; }
        }

        public class EjecutaValidacionPerfil : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacionPerfil()
            {
                RuleFor(x => x.Descripcion).NotEmpty();
            }
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
                var religion = await _context.TblCatReligion.FindAsync(request.IdReigion);
                if (religion == null)
                {
                    throw new Exception("La religion no existe");
                }

                religion.Descripcion = request.Descripcion ?? religion.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar la religion");
            }
        }
    }
}
