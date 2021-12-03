using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Nacionalidad
{
    public class EditarNacionalidad
    {
        public class EjecutaNacionalidad : IRequest
        {
            public Guid IdNacionalidad { get; set; }
            public string Descripcion { get; set; }
        }

        public class EjecutaValidacionNacionalidad : AbstractValidator<EjecutaNacionalidad>
        {
            public EjecutaValidacionNacionalidad()
            {
                
                RuleFor(x => x.Descripcion).NotEmpty();
              
              
               
            }
        }

        public class ManejadorNacionalidad : IRequestHandler<EjecutaNacionalidad>
        {
            private readonly netLisContext _context;

            public ManejadorNacionalidad(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaNacionalidad request, CancellationToken cancellationToken)
            {
                var Nacionalidad = await _context.TblCatNacionalidads.FindAsync(request.IdNacionalidad);
                if (Nacionalidad == null)
                {
                    throw new Exception("El Nacionalidad no existe");
                }
                
                Nacionalidad.Descripcion = request.Descripcion ?? Nacionalidad.Descripcion;
                

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el Nacionalidad");
            }
        }
    }
}
