using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.CatogoriaExamenes
{
    public class CategoriaExamenConsulta
    {
        public class EjecutaCategoriaExamen : IRequest<List<TblCatCategoriaExamenes>> { }

        public class ManejadorCategoriaExamen : IRequestHandler<EjecutaCategoriaExamen, List<TblCatCategoriaExamenes>>
        {
            private readonly netLisContext _context;
            public ManejadorCategoriaExamen(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatCategoriaExamenes>> Handle(EjecutaCategoriaExamen request, CancellationToken cancellationToken)
            {
                var catexamen = await _context.TblCatCategoriaExamenes.ToListAsync();
                return catexamen;
            }
        }
    }
}
