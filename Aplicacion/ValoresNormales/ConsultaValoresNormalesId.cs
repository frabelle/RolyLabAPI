using Dominio;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.ValoresNormales
{
    public class ConsultaValoresNormalesId
    {
        public class ValoresNormalesUnico : IRequest<TblCatValoresNormales>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<ValoresNormalesUnico, TblCatValoresNormales>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatValoresNormales> Handle(ValoresNormalesUnico request, CancellationToken cancellationToken)
            {
                var valorNormal = await _context.TblCatValoresNormales.FindAsync(request.Id);
                return valorNormal;
            }
        }
    }
}
