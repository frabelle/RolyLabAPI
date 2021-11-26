using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Identificacion
{
    public class IdentificacionConsulta
    {
        public class EjecutaIdentificacion : IRequest<List<TblCatIdentificacion>> { }

        public class ManejadorIdentificacion : IRequestHandler<EjecutaIdentificacion, List<TblCatIdentificacion>>
        {
            private readonly netLisContext _context;
            public ManejadorIdentificacion(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatIdentificacion>> Handle(EjecutaIdentificacion request, CancellationToken cancellationToken)
            {
                var identificacion = await _context.TblCatIdentificacions.ToListAsync();
                return identificacion;
            }
        }
    }
}
