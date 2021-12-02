using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoMuestra
{
    public class ConsultaTipoMuestraId
    {
        public class TipoMuestraUnica : IRequest<TblCatTipoMuestra>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<TipoMuestraUnica, TblCatTipoMuestra>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatTipoMuestra> Handle(TipoMuestraUnica request, CancellationToken cancellationToken)
            {
                var tipoMuestra = await _context.TblCatTipoMuestras.FindAsync(request.Id);
                return tipoMuestra;
            }
        }
    }
}
