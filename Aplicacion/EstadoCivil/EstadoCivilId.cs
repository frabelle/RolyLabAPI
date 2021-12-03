using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.EstadoCivil
{
    public class ConsultaEstadoCivilId
    {
        public class Unico : IRequest<TblCatEstadoCivil>
        {
            public Guid Id { get; set; }
        }

        public class ManejadorEstadoCivil : IRequestHandler<Unico, TblCatEstadoCivil>
        {
            private readonly netLisContext _context;
            public ManejadorEstadoCivil(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatEstadoCivil> Handle(Unico request, CancellationToken cancellationToken)
            {
                var EstadoCivil = await _context.TblCatEstadoCivils.FindAsync(request.Id);
                return EstadoCivil;
            }
        }
    }
}
