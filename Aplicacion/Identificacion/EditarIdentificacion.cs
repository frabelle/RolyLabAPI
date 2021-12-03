using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Identificacion
{
    public class EditarIdentificacion
    {
        public class EjecutaIdentificacion : IRequest
        {
            public Guid IdIdentificacion { get; set; }
            public Guid IdNacionalidad { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }
        }

        public class EjecutaValidacionIdentificacion : AbstractValidator<EjecutaIdentificacion>
        {
            public EjecutaValidacionIdentificacion()
            {
                RuleFor(x => x.IdNacionalidad).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
              
               
            }
        }

        public class ManejadorIdentificacion : IRequestHandler<EjecutaIdentificacion>
        {
            private readonly netLisContext _context;

            public ManejadorIdentificacion(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaIdentificacion request, CancellationToken cancellationToken)
            {
                var Identificacion = await _context.TblCatIdentificacions.FindAsync(request.IdIdentificacion);
                if (Identificacion == null)
                {
                    throw new Exception("El Identificacion no existe");
                }
                if (request.IdNacionalidad == Guid.Empty)
                {
                    Identificacion.IdNacionalidad = Identificacion.IdNacionalidad;
                }
                else
                {
                    Identificacion.IdNacionalidad = request.IdNacionalidad;
                }
                Identificacion.Descripcion = request.Descripcion ?? Identificacion.Descripcion;
                Identificacion.Estado = 2; 

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el Identificacion");
            }
        }
    }
}
