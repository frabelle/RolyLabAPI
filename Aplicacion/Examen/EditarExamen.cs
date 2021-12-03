using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Examen
{
    public class EditarExamen
    {
        public class EjecutaExamen : IRequest
        {
            public Guid IdExamen { get; set; }
            public Guid IdAreaLabServicio { get; set; }
            public Guid IdCategoriaExamenes { get; set; }
            public Guid IdTipoMuestra { get; set; }
            public Guid IdUnidadMedidas { get; set; }
            public Guid IdTipoResultado { get; set; }
            public string Descripcion { get; set; }
            public string DescripcionCorta { get; set; }
            public string Confidencial { get; set; }
            public int Estado { get; set; }
        }

        public class EjecutaValidacionExamen : AbstractValidator<EjecutaExamen>
        {
            public EjecutaValidacionExamen()
            {
                
                RuleFor(x => x.IdAreaLabServicio).NotEmpty();
                RuleFor(x => x.IdCategoriaExamenes).NotEmpty();
                RuleFor(x => x.IdTipoMuestra).NotEmpty();
                RuleFor(x => x.IdUnidadMedidas).NotEmpty();
                RuleFor(x => x.IdTipoResultado).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.DescripcionCorta).NotEmpty();
                RuleFor(x => x.Confidencial).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
                
               
            }
        }

        public class ManejadorExamen : IRequestHandler<EjecutaExamen>
        {
            private readonly netLisContext _context;

            public ManejadorExamen(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaExamen request, CancellationToken cancellationToken)
            {
                var Examen = await _context.TblExamenes.FindAsync(request.IdExamen);
                if (Examen == null)
                {
                    throw new Exception("El Examen no existe");
                }

                if (request.IdAreaLabServicio == Guid.Empty)
                {
                    Examen.IdAreaLabServicio = Examen.IdAreaLabServicio;
                }
                else
                {
                    Examen.IdAreaLabServicio = request.IdAreaLabServicio;
                }

                if (request.IdCategoriaExamenes == Guid.Empty)
                {
                    Examen.IdCategoriaExamenes = Examen.IdCategoriaExamenes;
                }
                else
                {
                    Examen.IdCategoriaExamenes = request.IdCategoriaExamenes;
                }

                if (request.IdTipoMuestra == Guid.Empty)
                {
                    Examen.IdTipoMuestra = Examen.IdTipoMuestra;
                }
                else
                {
                    Examen.IdTipoMuestra = request.IdTipoMuestra;
                }

                if (request.IdUnidadMedidas == Guid.Empty)
                {
                    Examen.IdUnidadMedidas = Examen.IdUnidadMedidas;
                }
                else
                {
                    Examen.IdUnidadMedidas = request.IdUnidadMedidas;
                }

                if (request.IdTipoResultado == Guid.Empty)
                {
                    Examen.IdTipoResultado = Examen.IdTipoResultado;
                }
                else
                {
                    Examen.IdTipoResultado = request.IdTipoResultado;
                }

                Examen.Descripcion = request.Descripcion ?? Examen.Descripcion;
                Examen.DescripcionCorta = request.DescripcionCorta ?? Examen.DescripcionCorta;
                Examen.Confidencial = request.Confidencial ?? Examen.Confidencial;
                Examen.Estado = 2; 

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el Examen");
            }
        }
    }
}
