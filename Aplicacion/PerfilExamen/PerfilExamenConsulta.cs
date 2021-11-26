using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.PerfilExamen
{
    public class PerfilExamenConsulta
    {
        public class EjecutaPerfilExamen : IRequest<List<TblCatPerfilesExamenes>> { }

        public class ManejadorPerfilExamen : IRequestHandler<EjecutaPerfilExamen, List<TblCatPerfilesExamenes>>
        {
            private readonly netLisContext _context;
            public ManejadorPerfilExamen(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatPerfilesExamenes>> Handle(EjecutaPerfilExamen request, CancellationToken cancellationToken)
            {
                var perfilExamen = await _context.TblCatPerfilesExamenes.ToListAsync();
                return perfilExamen;
            }
        }
    }
}
