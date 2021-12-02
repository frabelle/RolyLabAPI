using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Sexos
{
    public class EditarSexo
    {
        public class Ejecuta : IRequest
        {
            public Guid IdSexo { get; set; }
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
                var sexo = await _context.TblCatSexos.FindAsync(request.IdSexo);
                if (sexo == null)
                {
                    throw new Exception("El sexo no existe");
                }

                sexo.Descripcion = request.Descripcion ?? sexo.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el sexo");
            }
        }
    }
}
