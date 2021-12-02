using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoResultado
{
    public class EditarTipoResultado
    {
        public class Ejecuta : IRequest
        {
            public Guid IdTipoResultado { get; set; }
            public string Descripcion { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
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
                var tipoResultado = await _context.TblCatTipoResultados.FindAsync(request.IdTipoResultado);
                if (tipoResultado == null)
                {
                    throw new Exception("El tipo resultado no existe");
                }

                tipoResultado.Descripcion = request.Descripcion ?? tipoResultado.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el tipo resultado");
            }
        }
    }
}
