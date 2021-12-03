using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.CatogoriaExamenes
{
    public class ConsultaCategoriaExamenesId
    {
        public class Unico : IRequest<TblCatCategoriaExamenes>
        {
            public Guid Id { get; set; }
        }

        public class ManejadorCategoriaExamenes : IRequestHandler<Unico, TblCatCategoriaExamenes>
        {
            private readonly netLisContext _context;
            public ManejadorCategoriaExamenes(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatCategoriaExamenes> Handle(Unico request, CancellationToken cancellationToken)
            {
                var categoriaExamenes = await _context.TblCatCategoriaExamenes.FindAsync(request.Id);
                return categoriaExamenes;
            }
        }
    }
}
