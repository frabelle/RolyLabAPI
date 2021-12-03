using Dominio;
using Dominio.Model;
using FluentValidation;
using MediatR;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Examen
{
    public class NuevoExamen
    {
        public class EjecutaExamen : IRequest
        {
            //public Guid IdExamen { get; set; }
            public Guid IdAreaLabServicio { get; set; }
            public Guid IdCategoriaExamenes { get; set; }
            public Guid IdTipoMuestra { get; set; }
            public Guid IdUnidadMedidas { get; set; }
            public Guid IdTipoResultado { get; set; }
            public string Descripcion { get; set; }
            public string DescripcionCorta { get; set; }
            public string Confidencial { get; set; }
            public int Estado { get; set; }

            //public List<Guid> ListaExamenesExamenes { get; set; }
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
                Guid _idExamen = Guid.NewGuid();
                Debug.WriteLine(_idExamen);
                var Examen = new TblExamenes
                {
                    IdExamen = _idExamen,
                    IdAreaLabServicio = request.IdAreaLabServicio,
                    IdCategoriaExamenes = request.IdCategoriaExamenes,
                    IdTipoMuestra = request.IdTipoMuestra,
                    IdUnidadMedidas = request.IdUnidadMedidas,
                    IdTipoResultado = request.IdTipoResultado,
                    Descripcion = request.Descripcion,
                    DescripcionCorta = request.DescripcionCorta,
                    Confidencial = request.Confidencial,
                    Estado = 1
                   
                };

                _context.TblExamenes.Add(Examen);

                //Agregando en tabla CursoInstructor
                //if (request.ListaExamenesExamenes != null)
                //{
                //    foreach (var id in request.ListaExamenesExamenes)
                //    {
                //        var ExamenesExamenes = new TblCatExamenesExamenes
                //        {
                //            IdExamenes = _idExamen,
                //            IdExamenesExamenes = id
                //        };

                //        _context.TblCatExamenesExamenes.Add(ExamenesExamenes);
                //    }
                //}
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar el curso");
            }
        }
    }
}
