using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.UnidadMedida
{
    public class EditarUnidadMedida
    {
        public class Ejecuta : IRequest
        {
            public Guid IdUnidadMedidas { get; set; }
            public string UnidadMedida { get; set; }
            public int? Estado { get; set; }
        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.UnidadMedida).NotEmpty();
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
                var unidadMedida = await _context.TblCatUnidadMedidas.FindAsync(request.IdUnidadMedidas);
                if (unidadMedida == null)
                {
                    throw new Exception("La unidad de medida no existe");
                }

                unidadMedida.UnidadMedida = request.UnidadMedida ?? unidadMedida.UnidadMedida;
                unidadMedida.Estado = 2;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar la unidad de medida");
            }
        }
    }
}
