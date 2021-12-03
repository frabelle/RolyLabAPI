using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Pais
{
    public class ConsultaPaisId
    {
        public class Unico : IRequest<TblCatPais>
        {
            public Guid Id { get; set; }
        }

        public class ManejadorPais : IRequestHandler<Unico, TblCatPais>
        {
            private readonly netLisContext _context;
            public ManejadorPais(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatPais> Handle(Unico request, CancellationToken cancellationToken)
            {
                var Pais = await _context.TblCatPais.FindAsync(request.Id);
                return Pais;
            }
        }
    }
}
