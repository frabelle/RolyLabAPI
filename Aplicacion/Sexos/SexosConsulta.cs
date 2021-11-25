using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Aplicacion.Pais.Consulta;

namespace Aplicacion.Sexos
{
    public class SexosConsulta
    {
        public class EjecutaSexos : IRequest<List<TblCatSexos>> { }

        public class ManejadorSexos : IRequestHandler<EjecutaSexos, List<TblCatSexos>>
        {
            private readonly netLisContext _context;
            public ManejadorSexos(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatSexos>> Handle(EjecutaSexos request, CancellationToken cancellationToken)
            {
                var sexos = await _context.TblCatSexos.ToListAsync();
                return sexos;
            }
        }
    }
}
