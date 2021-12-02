using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoResultado
{
    public class ConsultaTipoResultado
    {
        public class TipoTipoResultadoUnico : IRequest<TblCatTipoResultado>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<TipoTipoResultadoUnico, TblCatTipoResultado>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatTipoResultado> Handle(TipoTipoResultadoUnico request, CancellationToken cancellationToken)
            {
                var tipoResultado = await _context.TblCatTipoResultados.FindAsync(request.Id);
                return tipoResultado;
            }
        }
    }
}
