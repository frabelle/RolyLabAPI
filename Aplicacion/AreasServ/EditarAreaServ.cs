using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.AreasServ
{
    public class EditarAreaServ
    {
        public class EjecutaAreaServ : IRequest
        {
            public Guid IdAreaServ { get; set; }
            public string Descripcion { get; set; }
            public string DescripcionCorta { get; set; }
            public int Estado { get; set; }
        }

        public class EjecutaValidacionAreaServ : AbstractValidator<EjecutaAreaServ>
        {
            public EjecutaValidacionAreaServ()
            {
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
                RuleFor(x => x.DescripcionCorta).NotEmpty();
            }
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
                var AreaServ = await _context.TblCatAreasServs.FindAsync(request.IdAreaServ);
                if (AreaServ == null)
                {
                    throw new Exception("El AreaServ no existe");
                }   

                AreaServ.Descripcion = request.Descripcion ?? AreaServ.Descripcion;
                AreaServ.DescripcionCorta = request.DescripcionCorta ?? AreaServ.DescripcionCorta; 
                AreaServ.Estado = 2; 

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el AreaServ");
            }
        }
    }
}
