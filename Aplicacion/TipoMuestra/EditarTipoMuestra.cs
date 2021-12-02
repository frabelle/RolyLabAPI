using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoMuestra
{
    public class EditarTipoMuestra
    {
        public class Ejecuta : IRequest
        {
            public Guid IdTipoMuestra { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
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
                var tipoMuestra = await _context.TblCatTipoMuestras.FindAsync(request.IdTipoMuestra);
                if (tipoMuestra == null)
                {
                    throw new Exception("El tipo muestra no existe");
                }

                tipoMuestra.Descripcion = request.Descripcion ?? tipoMuestra.Descripcion;
                tipoMuestra.Estado = 2;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el tipo muestra");
            }
        }
    }
}
