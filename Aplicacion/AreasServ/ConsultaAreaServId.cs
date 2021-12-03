using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.AreasServ
{
    public class ConsultaAreaServId
    {
        public class Unico : IRequest<TblCatAreasServ>
        {
            public Guid Id { get; set; }
        }

        public class ManejadorAreaServ : IRequestHandler<Unico, TblCatAreasServ>
        {
            private readonly netLisContext _context;
            public ManejadorAreaServ(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatAreasServ> Handle(Unico request, CancellationToken cancellationToken)
            {
                var areaServ = await _context.TblCatAreasServs.FindAsync(request.Id);
                return areaServ;
            }
        }
    }
}
