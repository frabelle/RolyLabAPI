using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoResultado
{
    public class TipoResultadoConsulta
    {
        public class EjecutaTipoResultado : IRequest<List<TblCatTipoResultado>> { }

        public class ManejadorTipoResultado : IRequestHandler<EjecutaTipoResultado, List<TblCatTipoResultado>>
        {
            private readonly netLisContext _context;
            public ManejadorTipoResultado(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatTipoResultado>> Handle(EjecutaTipoResultado request, CancellationToken cancellationToken)
            {
                var tipoResultado = await _context.TblCatTipoResultados.ToListAsync();
                return tipoResultado;
            }
        }
    }
}
