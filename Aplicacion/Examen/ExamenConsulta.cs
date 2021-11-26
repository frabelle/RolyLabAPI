using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Examen
{
    public class ExamenConsulta
    {
        public class EjecutaExamen : IRequest<List<TblExamenes>> { }

        public class ManejadorExamen : IRequestHandler<EjecutaExamen, List<TblExamenes>>
        {
            private readonly netLisContext _context;
            public ManejadorExamen(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblExamenes>> Handle(EjecutaExamen request, CancellationToken cancellationToken)
            {
                var profesion = await _context.TblExamenes.ToListAsync();
                return profesion;
            }
        }
    }
}
