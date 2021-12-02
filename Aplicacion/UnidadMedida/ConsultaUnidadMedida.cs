using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.UnidadMedida
{
    public class ConsultaUnidadMedida
    {
        public class UnidadMedidaUnica : IRequest<TblCatUnidadMedida>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<UnidadMedidaUnica, TblCatUnidadMedida>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatUnidadMedida> Handle(UnidadMedidaUnica request, CancellationToken cancellationToken)
            {
                var unidadMedida = await _context.TblCatUnidadMedidas.FindAsync(request.Id);
                return unidadMedida;
            }
        }
    }
}
