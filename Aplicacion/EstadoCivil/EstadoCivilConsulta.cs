using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.EstadoCivil
{
    public class EstadoCivilConsulta
    {
        public class EjecutaEstadoCivil : IRequest<List<TblCatEstadoCivil>> { }

        public class ManejadorEstadoCivil : IRequestHandler<EjecutaEstadoCivil, List<TblCatEstadoCivil>>
        {
            private readonly netLisContext _context;
            public ManejadorEstadoCivil(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatEstadoCivil>> Handle(EjecutaEstadoCivil request, CancellationToken cancellationToken)
            {
                var estadoCivil = await _context.TblCatEstadoCivils.ToListAsync();
                return estadoCivil;
            }
        }
    }
}
