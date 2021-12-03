using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Departamentos
{
    public class ConsultaDepartamentoId
    {
        public class Unico : IRequest<TblCatDepartamento>
        {
            public Guid Id { get; set; }
        }

        public class ManejadorDepartamento : IRequestHandler<Unico, TblCatDepartamento>
        {
            private readonly netLisContext _context;
            public ManejadorDepartamento(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatDepartamento> Handle(Unico request, CancellationToken cancellationToken)
            {
                var Departamento = await _context.TblCatDepartamentos.FindAsync(request.Id);
                return Departamento;
            }
        }
    }
}
