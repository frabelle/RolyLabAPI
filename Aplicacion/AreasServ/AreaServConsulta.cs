using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.AreasServ
{
    public class AreaServConsulta
    {
        public class EjecutaAreaServ : IRequest<List<TblCatAreasServ>> { }

        public class ManejadorAreasServ : IRequestHandler<EjecutaAreaServ, List<TblCatAreasServ>>
        {
            private readonly netLisContext _context;
            public ManejadorAreasServ(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatAreasServ>> Handle(EjecutaAreaServ request, CancellationToken cancellationToken)
            {
                var profesion = await _context.TblCatAreasServs.ToListAsync();
                return profesion;
            }
        }
    }
}
