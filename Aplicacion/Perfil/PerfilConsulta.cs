using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Perfil
{
    public class PerfilConsulta
    {
        public class EjecutaPerfil : IRequest<List<TblCatPerfiles>> { }

        public class ManejadorPerfil : IRequestHandler<EjecutaPerfil, List<TblCatPerfiles>>
        {
            private readonly netLisContext _context;
            public ManejadorPerfil(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatPerfiles>> Handle(EjecutaPerfil request, CancellationToken cancellationToken)
            {
                var perfiles = await _context.TblCatPerfiles.ToListAsync();
                return perfiles;
            }
        }
    }
}
