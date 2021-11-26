using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Sucursales
{
   public class SucursalesConsulta
    {
        public class EjecutaSucursales : IRequest<List<TblCatSucursales>> { }

        public class ManejadorSucursales : IRequestHandler<EjecutaSucursales, List<TblCatSucursales>>
        {
            private readonly netLisContext _context;
            public ManejadorSucursales(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatSucursales>> Handle(EjecutaSucursales request, CancellationToken cancellationToken)
            {
                var sucursales = await _context.TblCatSucursales.ToListAsync();
                return sucursales;
            }
        }
    }
}
