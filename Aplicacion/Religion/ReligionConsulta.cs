using Dominio;
using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Religion
{
    public class ReligionConsulta
    {
        public class EjecutaReligion : IRequest<List<TblCatReligion>> { }

        public class ManejadorReligion : IRequestHandler<EjecutaReligion, List<TblCatReligion>>
        {
            private readonly netLisContext _context;
            public ManejadorReligion(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatReligion>> Handle(EjecutaReligion request, CancellationToken cancellationToken)
            {
                var religion = await _context.TblCatReligion.ToListAsync();
                return religion;
            }
        }
    }
}
