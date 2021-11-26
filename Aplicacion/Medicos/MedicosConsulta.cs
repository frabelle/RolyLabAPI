using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Medicos
{
   public class MedicosConsulta
    {
        public class EjecutaMedicos : IRequest<List<TblMedico>> { }

        public class ManejadorMedicos : IRequestHandler<EjecutaMedicos, List<TblMedico>>
        {
            private readonly netLisContext _context;
            public ManejadorMedicos(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblMedico>> Handle(EjecutaMedicos request, CancellationToken cancellationToken)
            {
                var medicos = await _context.TblMedicos.ToListAsync();
                return medicos;
            }
        }
    }
}
