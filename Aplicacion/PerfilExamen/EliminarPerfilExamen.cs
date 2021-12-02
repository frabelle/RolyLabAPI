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

namespace Aplicacion.PerfilExamen
{
    public class EliminarPerfilExamen
    {
        public class Ejecuta : IRequest
        {
            public Guid Id { get; set; }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly netLisContext _context;
            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var perfilesExamenes = await _context.TblCatPerfilesExamenes.FindAsync(request.Id);
                if (perfilesExamenes == null)
                {
                    throw new Exception();
                        //ManejadorExcepcion(HttpStatusCode.NotFound, new { perfiles = "No se encontró el curso"});
                }
                _context.Remove(perfilesExamenes);

                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar el perfil de examen");
            }
        }
    }
}
