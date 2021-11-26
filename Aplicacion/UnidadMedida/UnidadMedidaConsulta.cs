using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.UnidadMedida
{
    public class UnidadMedidaConsulta
    {
        public class EjecutaUnidadMedida : IRequest<List<TblCatUnidadMedida>> { }

        public class ManejadorUnidadMedida : IRequestHandler<EjecutaUnidadMedida, List<TblCatUnidadMedida>>
        {
            private readonly netLisContext _context;
            public ManejadorUnidadMedida(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatUnidadMedida>> Handle(EjecutaUnidadMedida request, CancellationToken cancellationToken)
            {
                var unidadMedidas = await _context.TblCatUnidadMedidas.ToListAsync();
                return unidadMedidas;
            }
        }
    }
}
