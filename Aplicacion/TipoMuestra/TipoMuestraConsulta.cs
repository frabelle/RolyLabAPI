using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoMuestra
{
    public class TipoMuestraConsulta
    {
        public class EjecutaTipoMuestra : IRequest<List<TblCatTipoMuestra>> { }

        public class ManejadorTipoMuestra : IRequestHandler<EjecutaTipoMuestra, List<TblCatTipoMuestra>>
        {
            private readonly netLisContext _context;
            public ManejadorTipoMuestra(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatTipoMuestra>> Handle(EjecutaTipoMuestra request, CancellationToken cancellationToken)
            {
                var tipoMuestras = await _context.TblCatTipoMuestras.ToListAsync();
                return tipoMuestras;
            }
        }
    }
}
