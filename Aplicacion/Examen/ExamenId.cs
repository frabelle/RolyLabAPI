using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Examen
{
    public class ConsultaExamenId
    {
        public class Unico : IRequest<TblExamenes>
        {
            public Guid Id { get; set; }
        }

        public class ManejadorExamen : IRequestHandler<Unico, TblExamenes>
        {
            private readonly netLisContext _context;
            public ManejadorExamen(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblExamenes> Handle(Unico request, CancellationToken cancellationToken)
            {
                var Examen = await _context.TblExamenes.FindAsync(request.Id);
                return Examen;
            }
        }
    }
}
