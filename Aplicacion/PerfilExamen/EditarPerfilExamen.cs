using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.PerfilExamen
{
    public class EditarPerfilExamen
    {
        public class Ejecuta : IRequest
        {
            public Guid IdPerfilesExamenes { get; set; }
            public Guid IdExamen { get; set; }
            public Guid IdPerfiles { get; set; }
        }

        public class EjecutaValidacionPerfil : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacionPerfil()
            {
                RuleFor(x => x.IdExamen).NotEmpty();
                RuleFor(x => x.IdPerfiles).NotEmpty();
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
                var perfilExamen = await _context.TblCatPerfilesExamenes.FindAsync(request.IdPerfilesExamenes);
                if (perfilExamen == null)
                {
                    throw new Exception("El perfil de examen no existe");
                }

                if(request.IdExamen == Guid.Empty)
                {
                    perfilExamen.IdExamen = perfilExamen.IdExamen;
                } else
                {
                    perfilExamen.IdExamen = request.IdExamen;
                }

                if (request.IdPerfiles == Guid.Empty)
                {
                    perfilExamen.IdPerfiles = perfilExamen.IdPerfiles;
                }
                else
                {
                    perfilExamen.IdPerfiles = request.IdPerfiles;
                }

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el perfil de examen");
            }
        }
    }
}
