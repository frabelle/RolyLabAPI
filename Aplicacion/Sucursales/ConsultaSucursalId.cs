using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Sucursales
{
    public class ConsultaSucursalId
    {
        public class SucursalUnica : IRequest<TblCatSucursales>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<SucursalUnica, TblCatSucursales>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatSucursales> Handle(SucursalUnica request, CancellationToken cancellationToken)
            {
                var sucursal = await _context.TblCatSucursales.FindAsync(request.Id);
                return sucursal;
            }
        }
    }
}
