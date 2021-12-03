using Aplicacion.ManejadorError;
using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Paciente
{
    public class EliminarPaciente
    {
        public class EjecutaPaciente : IRequest
        {
            public Guid Id { get; set; }
        }
        public class ManejadorPaciente : IRequestHandler<EjecutaPaciente>
        {
            private readonly netLisContext _context;
            public ManejadorPaciente(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaPaciente request, CancellationToken cancellationToken)
            {
                var Pacientes = await _context.TblPacientes.FindAsync(request.Id);
                if (Pacientes == null)
                {
                    throw new Exception();
                        //ManejadorExcepcion(HttpStatusCode.NotFound, new { Pacientees = "No se encontró el curso"});
                }
                _context.Remove(Pacientes);

                var resultado = await _context.SaveChangesAsync();

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo eliminar el curso");
            }
        }
    }
}
