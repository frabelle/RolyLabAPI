using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Profesiones
{
   public class ProfesionesConsulta
    {
        public class EjecutaProfesiones : IRequest<List<TblCatProfesiones>> { }

        public class ManejadorProfesiones : IRequestHandler<EjecutaProfesiones, List<TblCatProfesiones>>
        {
            private readonly netLisContext _context;
            public ManejadorProfesiones(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatProfesiones>> Handle(EjecutaProfesiones request, CancellationToken cancellationToken)
            {
                var profesiones = await _context.TblCatProfesiones.ToListAsync();
                return profesiones;
            }
        }
    }
}
