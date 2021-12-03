using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Paciente
{
    public class ConsultaPacienteId
    {
        public class Unico : IRequest<TblPaciente>
        {
            public Guid Id { get; set; }
        }

        public class ManejadorPaciente : IRequestHandler<Unico, TblPaciente>
        {
            private readonly netLisContext _context;
            public ManejadorPaciente(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblPaciente> Handle(Unico request, CancellationToken cancellationToken)
            {
                var Paciente = await _context.TblPacientes.FindAsync(request.Id);
                return Paciente;
            }
        }
    }
}
