using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.PerfilExamen
{
    public class ConsultaPerfilExamenId
    {
        public class PerfilExamenUnico : IRequest<TblCatPerfilesExamenes>
        {
            public Guid Id { get; set; }
        }

        public class ManejadorPerfilExamen : IRequestHandler<PerfilExamenUnico, TblCatPerfilesExamenes>
        {
            private readonly netLisContext _context;
            public ManejadorPerfilExamen(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatPerfilesExamenes> Handle(PerfilExamenUnico request, CancellationToken cancellationToken)
            {
                var perfilExamen = await _context.TblCatPerfilesExamenes.FindAsync(request.Id);
                return perfilExamen;
            }
        }
    }
}
