using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.ValoresNormales
{
    public class ValoresNormalesConsulta
    {
        public class EjecutaValoresNormales : IRequest<List<TblCatValoresNormales>> { }

        public class ManejadorValoresNormales : IRequestHandler<EjecutaValoresNormales, List<TblCatValoresNormales>>
        {
            private readonly netLisContext _context;
            public ManejadorValoresNormales(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatValoresNormales>> Handle(EjecutaValoresNormales request, CancellationToken cancellationToken)
            {
                var valorNormal = await _context.TblCatValoresNormales.ToListAsync();
                return valorNormal;
            }
        }
    }
}
