using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.CatogoriaExamenes
{
    public class EditarCategoriaExamenes
    {
        public class EjecutaCategoriaExamenes : IRequest
        {
            public Guid IdCategoriaExamenes { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }
        }

        public class EjecutaValidacionCategoriaExamenes : AbstractValidator<EjecutaCategoriaExamenes>
        {
            public EjecutaValidacionCategoriaExamenes()
            {
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
            }
        }

        public class ManejadorCategoriaExamenes : IRequestHandler<EjecutaCategoriaExamenes>
        {
            private readonly netLisContext _context;

            public ManejadorCategoriaExamenes(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaCategoriaExamenes request, CancellationToken cancellationToken)
            {
                var CategoriaExamenes = await _context.TblCatCategoriaExamenes.FindAsync(request.IdCategoriaExamenes);
                if (CategoriaExamenes == null)
                {
                    throw new Exception("El CategoriaExamenes no existe");
                }   

                CategoriaExamenes.Descripcion = request.Descripcion ?? CategoriaExamenes.Descripcion;
                CategoriaExamenes.Estado = 2; 

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el CategoriaExamenes");
            }
        }
    }
}
