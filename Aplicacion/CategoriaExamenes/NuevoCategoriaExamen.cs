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

namespace Aplicacion.CatogoriaExamenes
{
    public class NuevoCategoriaExamenes
    {
        public class EjecutaCategoriaExamenes : IRequest
        {
            //public Guid IdCategoriaExamenes { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }

            //public List<Guid> ListaCategoriaExamenesesExamenes { get; set; }
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
                Guid _idCategoriaExamenes = Guid.NewGuid();
                Debug.WriteLine(_idCategoriaExamenes);
                var CategoriaExamenes = new TblCatCategoriaExamenes
                {
                    IdCategoriaExamenes = _idCategoriaExamenes,
                    Descripcion = request.Descripcion,
                    Estado = 1
                   
                };

                _context.TblCatCategoriaExamenes.Add(CategoriaExamenes);

                //Agregando en tabla CursoInstructor
                //if (request.ListaCategoriaExamenesesExamenes != null)
                //{
                //    foreach (var id in request.ListaCategoriaExamenesesExamenes)
                //    {
                //        var CategoriaExamenesesExamenes = new TblCatCategoriaExamenesesExamenes
                //        {
                //            IdCategoriaExameneses = _idCategoriaExamenes,
                //            IdCategoriaExamenesesExamenes = id
                //        };

                //        _context.TblCatCategoriaExamenesesExamenes.Add(CategoriaExamenesesExamenes);
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
