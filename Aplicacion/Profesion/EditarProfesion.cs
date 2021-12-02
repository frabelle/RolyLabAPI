using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Profesion
{
    public class EditarProfesion
    {
        public class Ejecuta : IRequest
        {
            public Guid IdProfesiones { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }
        }

        public class EjecutaValidacionPerfil : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacionPerfil()
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
                var profesion = await _context.TblCatProfesiones.FindAsync(request.IdProfesiones);
                if (profesion == null)
                {
                    throw new Exception("La profesion no existe");
                }

                profesion.Descripcion = request.Descripcion ?? profesion.Descripcion;
                profesion.Estado = 2;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar la profesion");
            }
        }
    }
}
