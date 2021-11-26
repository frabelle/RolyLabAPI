using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Departamentos
{
   public class DepartamentoConsulta
    {
        public class EjecutaDepartamento : IRequest<List<TblCatDepartamento>> { }

        public class ManejadorDepartamento : IRequestHandler<EjecutaDepartamento, List<TblCatDepartamento>>
        {
            private readonly netLisContext _context;
            public ManejadorDepartamento(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatDepartamento>> Handle(EjecutaDepartamento request, CancellationToken cancellationToken)
            {
                var departamento = await _context.TblCatDepartamentos.ToListAsync();
                return departamento;
            }
        }
    }
}
