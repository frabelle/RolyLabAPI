using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Nacionalidad
{
    public class ConsultaNacionalidadId
    {
        public class Unico : IRequest<TblCatNacionalidad>
        {
            public Guid Id { get; set; }
        }

        public class ManejadorNacionalidad : IRequestHandler<Unico, TblCatNacionalidad>
        {
            private readonly netLisContext _context;
            public ManejadorNacionalidad(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatNacionalidad> Handle(Unico request, CancellationToken cancellationToken)
            {
                var Nacionalidad = await _context.TblCatNacionalidads.FindAsync(request.Id);
                return Nacionalidad;
            }
        }
    }
}
