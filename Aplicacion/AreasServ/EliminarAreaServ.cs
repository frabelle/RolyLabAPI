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

namespace Aplicacion.AreasServ
{
    public class EliminarAreaServ
    {
        public class EjecutaAreaServ : IRequest
        {
            public Guid Id { get; set; }
        }
        public class ManejadorAreaServ : IRequestHandler<EjecutaAreaServ>
        {
            private readonly netLisContext _context;
            public ManejadorAreaServ(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaAreaServ request, CancellationToken cancellationToken)
            {
                var AreaServes = await _context.TblCatAreasServs.FindAsync(request.Id);
                if (AreaServes == null)
                {
                    throw new Exception("No se encontro");
                        //ManejadorExcepcion(HttpStatusCode.NotFound, new { AreaServes = "No se encontró el curso"});
                }
                _context.Remove(AreaServes);

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
