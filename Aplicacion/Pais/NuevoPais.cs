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

namespace Aplicacion.Pais
{
    public class NuevoPais
    {
        public class EjecutaPais : IRequest
        {
            //public Guid IdPais { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }

            //public List<Guid> ListaPaisesExamenes { get; set; }
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
                Guid _idPais = Guid.NewGuid();
                Debug.WriteLine(_idPais);
                var Pais = new TblCatPais
                {
                    IdPais = _idPais,
                    Descripcion = request.Descripcion,
                    Estado = 1
                   
                };

                _context.TblCatPais.Add(Pais);

                //Agregando en tabla CursoInstructor
                //if (request.ListaPaisesExamenes != null)
                //{
                //    foreach (var id in request.ListaPaisesExamenes)
                //    {
                //        var PaisesExamenes = new TblCatPaisesExamenes
                //        {
                //            IdPaises = _idPais,
                //            IdPaisesExamenes = id
                //        };

                //        _context.TblCatPaisesExamenes.Add(PaisesExamenes);
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
