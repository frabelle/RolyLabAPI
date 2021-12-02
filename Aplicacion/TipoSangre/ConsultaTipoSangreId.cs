using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.TipoSangre
{
    public class ConsultaTipoSangre
    {
        public class TipoSangreUnico : IRequest<TblCatTipoSangre>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<TipoSangreUnico, TblCatTipoSangre>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatTipoSangre> Handle(TipoSangreUnico request, CancellationToken cancellationToken)
            {
                var tipoSangre = await _context.TblCatTipoSangre.FindAsync(request.Id);
                return tipoSangre;
            }
        }
    }
}
