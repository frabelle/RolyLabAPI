using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Perfil
{
    public class ConsultaPerfilId
    {
        public class PerfilUnico : IRequest<TblCatPerfiles>
        {
            public Guid Id { get; set; }
        }

        public class ManejadorPerfil : IRequestHandler<PerfilUnico, TblCatPerfiles>
        {
            private readonly netLisContext _context;
            public ManejadorPerfil(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatPerfiles> Handle(PerfilUnico request, CancellationToken cancellationToken)
            {
                var perfil = await _context.TblCatPerfiles.FindAsync(request.Id);
                return perfil;
            }
        }
    }
}
