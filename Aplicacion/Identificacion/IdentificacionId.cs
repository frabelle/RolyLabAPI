using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Identificacion
{
    public class ConsultaIdentificacionId
    {
        public class Unico : IRequest<TblCatIdentificacion>
        {
            public Guid Id { get; set; }
        }

        public class ManejadorIdentificacion : IRequestHandler<Unico, TblCatIdentificacion>
        {
            private readonly netLisContext _context;
            public ManejadorIdentificacion(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatIdentificacion> Handle(Unico request, CancellationToken cancellationToken)
            {
                var Identificacion = await _context.TblCatIdentificacions.FindAsync(request.Id);
                return Identificacion;
            }
        }
    }
}
