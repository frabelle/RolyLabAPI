using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Paciente
{
    public class PacienteConsulta
    {
        public class EjecutaPaciente : IRequest<List<TblPaciente>> { }

        public class ManejadorReligion : IRequestHandler<EjecutaPaciente, List<TblPaciente>>
        {
            private readonly netLisContext _context;
            public ManejadorReligion(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblPaciente>> Handle(EjecutaPaciente request, CancellationToken cancellationToken)
            {
                var pacientes = await _context.TblPacientes.ToListAsync();
                return pacientes;
            }
        }
    }
}
