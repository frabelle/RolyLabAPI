using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Profesion
{
    public class ProfesionConsulta
    {
        public class EjecutaProfesion : IRequest<List<TblCatProfesiones>> { }

        public class ManejadorProfesion : IRequestHandler<EjecutaProfesion, List<TblCatProfesiones>>
        {
            private readonly netLisContext _context;
            public ManejadorProfesion(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatProfesiones>> Handle(EjecutaProfesion request, CancellationToken cancellationToken)
            {
                var profesion = await _context.TblCatProfesiones.ToListAsync();
                return profesion;
            }
        }
    }
}
