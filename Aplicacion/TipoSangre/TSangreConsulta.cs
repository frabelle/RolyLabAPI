using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoSangre
{
    public class TSangreConsulta
    {
        public class EjecutaTipoSangre : IRequest<List<TblCatTipoSangre>> { }

        public class ManejadorTipoSangre : IRequestHandler<EjecutaTipoSangre, List<TblCatTipoSangre>>
        {
            private readonly netLisContext _context;
            public ManejadorTipoSangre(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatTipoSangre>> Handle(EjecutaTipoSangre request, CancellationToken cancellationToken)
            {
                var tipoSangre = await _context.TblCatTipoSangre.ToListAsync();
                return tipoSangre;
            }
        }
    }
}
