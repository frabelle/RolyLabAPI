using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Nacionalidad
{
    public class NacionalidadConsulta
    {
        public class EjecutaNacionalidad : IRequest<List<TblCatNacionalidad>> { }

        public class ManejadorNacionalidad : IRequestHandler<EjecutaNacionalidad, List<TblCatNacionalidad>>
        {
            private readonly netLisContext _context;
            public ManejadorNacionalidad(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatNacionalidad>> Handle(EjecutaNacionalidad request, CancellationToken cancellationToken)
            {
                var nacionalidad = await _context.TblCatNacionalidads.ToListAsync();
                return nacionalidad;
            }
        }
    }
}
