using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Perfil
{
    public class EditarPerfil
    {
        public class EjecutaPerfil : IRequest
        {
            public Guid IdPerfiles { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }
        }

        public class EjecutaValidacionPerfil : AbstractValidator<EjecutaPerfil>
        {
            public EjecutaValidacionPerfil()
            {
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
            }
        }

        public class ManejadorPerfil : IRequestHandler<EjecutaPerfil>
        {
            private readonly netLisContext _context;

            public ManejadorPerfil(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaPerfil request, CancellationToken cancellationToken)
            {
                var perfil = await _context.TblCatPerfiles.FindAsync(request.IdPerfiles);
                if (perfil == null)
                {
                    throw new Exception("El perfil no existe");
                }   

                perfil.Descripcion = request.Descripcion ?? perfil.Descripcion;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el perfil");
            }
        }
    }
}
