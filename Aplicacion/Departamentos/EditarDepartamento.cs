using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Departamentos
{
    public class EditarDepartamento
    {
        public class EjecutaDepartamento : IRequest
        {
            public Guid IdDepartamento { get; set; }
            public Guid IdPais { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }
        }

        public class EjecutaValidacionDepartamento : AbstractValidator<EjecutaDepartamento>
        {
            public EjecutaValidacionDepartamento()
            {
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
                RuleFor(x => x.IdPais).NotEmpty();
               
            }
        }

        public class ManejadorDepartamento : IRequestHandler<EjecutaDepartamento>
        {
            private readonly netLisContext _context;

            public ManejadorDepartamento(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaDepartamento request, CancellationToken cancellationToken)
            {
                var Departamento = await _context.TblCatDepartamentos.FindAsync(request.IdDepartamento);
                if (Departamento == null)
                {
                    throw new Exception("El Departamento no existe");
                }
                if (request.IdPais == Guid.Empty)
                {
                    Departamento.IdPais = Departamento.IdPais;
                }
                else
                {
                    Departamento.IdPais = request.IdPais;
                }
                Departamento.Descripcion = request.Descripcion ?? Departamento.Descripcion;
                Departamento.Estado = 2; 

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el Departamento");
            }
        }
    }
}
