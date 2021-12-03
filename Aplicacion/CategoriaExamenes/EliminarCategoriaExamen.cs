using Aplicacion.ManejadorError;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.CatogoriaExamenes
{
    public class EliminarCategoriaExamenes
    {
        public class EjecutaCategoriaExamenes : IRequest
        {
            public Guid Id { get; set; }
        }
        public class ManejadorCategoriaExamenes : IRequestHandler<EjecutaCategoriaExamenes>
        {
            private readonly netLisContext _context;
            public ManejadorCategoriaExamenes(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaCategoriaExamenes request, CancellationToken cancellationToken)
            {
                var CategoriaExameneses = await _context.TblCatCategoriaExamenes.FindAsync(request.Id);
                if (CategoriaExameneses == null)
                {
                    throw new Exception("No se encontro");
                        //ManejadorExcepcion(HttpStatusCode.NotFound, new { CategoriaExameneses = "No se encontró el curso"});
                }
                _context.Remove(CategoriaExameneses);

                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar el curso");
            }
        }
    }
}
