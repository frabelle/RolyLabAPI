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

namespace Aplicacion.EstadoCivil
{
    public class NuevoEstadoCivil
    {
        public class EjecutaEstadoCivil : IRequest
        {
            //public Guid IdEstadoCivil { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }

            //public List<Guid> ListaEstadoCivilesExamenes { get; set; }
        }
        public class EjecutaValidacionEstadoCivil : AbstractValidator<EjecutaEstadoCivil>
        {
            public EjecutaValidacionEstadoCivil()
            {
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
                
                
            }
        }

        public class ManejadorEstadoCivil : IRequestHandler<EjecutaEstadoCivil>
        {
            private readonly netLisContext _context;
            public ManejadorEstadoCivil(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaEstadoCivil request, CancellationToken cancellationToken)
            {
                Guid _idEstadoCivil = Guid.NewGuid();
                Debug.WriteLine(_idEstadoCivil);
                var EstadoCivil = new TblCatEstadoCivil
                {
                    IdEstadoCivil = _idEstadoCivil,
                    Descripcion = request.Descripcion,
                    Estado = 1
                   
                };

                _context.TblCatEstadoCivils.Add(EstadoCivil);

                //Agregando en tabla CursoInstructor
                //if (request.ListaEstadoCivilesExamenes != null)
                //{
                //    foreach (var id in request.ListaEstadoCivilesExamenes)
                //    {
                //        var EstadoCivilesExamenes = new TblCatEstadoCivilesExamenes
                //        {
                //            IdEstadoCiviles = _idEstadoCivil,
                //            IdEstadoCivilesExamenes = id
                //        };

                //        _context.TblCatEstadoCivilesExamenes.Add(EstadoCivilesExamenes);
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
