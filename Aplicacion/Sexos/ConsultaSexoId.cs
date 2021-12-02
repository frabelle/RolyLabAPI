using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Sexos
{
    public class ConsultaSexoId
    {
        public class SexoUnico : IRequest<TblCatSexos>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<SexoUnico, TblCatSexos>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatSexos> Handle(SexoUnico request, CancellationToken cancellationToken)
            {
                var sexo = await _context.TblCatSexos.FindAsync(request.Id);
                return sexo;
            }
        }
    }
}
