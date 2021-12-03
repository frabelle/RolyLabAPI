using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Medicos
{
    public class ConsultaMedicoId
    {
        public class Unico : IRequest<TblMedico>
        {
            public Guid Id { get; set; }
        }

        public class ManejadorMedico : IRequestHandler<Unico, TblMedico>
        {
            private readonly netLisContext _context;
            public ManejadorMedico(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblMedico> Handle(Unico request, CancellationToken cancellationToken)
            {
                var Medico = await _context.TblMedicos.FindAsync(request.Id);
                return Medico;
            }
        }
    }
}
