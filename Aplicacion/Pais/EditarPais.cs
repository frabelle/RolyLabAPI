using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Pais
{
    public class EditarPais
    {
        public class EjecutaPais : IRequest
        {
            public Guid IdPais { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }
        }

        public class EjecutaValidacionPais : AbstractValidator<EjecutaPais>
        {
            public EjecutaValidacionPais()
            {
                
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
              
               
            }
        }

        public class ManejadorPais : IRequestHandler<EjecutaPais>
        {
            private readonly netLisContext _context;

            public ManejadorPais(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaPais request, CancellationToken cancellationToken)
            {
                var Pais = await _context.TblCatPais.FindAsync(request.IdPais);
                if (Pais == null)
                {
                    throw new Exception("El Pais no existe");
                }
              
                Pais.Descripcion = request.Descripcion ?? Pais.Descripcion;
                Pais.Estado = 2; 

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el Pais");
            }
        }
    }
}
