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

namespace Aplicacion.Identificacion
{
    public class NuevoIdentificacion
    {
        public class EjecutaIdentificacion : IRequest
        {
            //public Guid IdIdentificacion { get; set; }
            public Guid IdNacionalidad { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }

            //public List<Guid> ListaIdentificacionesExamenes { get; set; }
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
                Guid _idIdentificacion = Guid.NewGuid();
                Debug.WriteLine(_idIdentificacion);
                var Identificacion = new TblCatIdentificacion
                {
                    IdIdentificacion = _idIdentificacion,
                    Descripcion = request.Descripcion,
                    IdNacionalidad = request.IdNacionalidad,
                    Estado = 1
                   
                };

                _context.TblCatIdentificacions.Add(Identificacion);

                //Agregando en tabla CursoInstructor
                //if (request.ListaIdentificacionesExamenes != null)
                //{
                //    foreach (var id in request.ListaIdentificacionesExamenes)
                //    {
                //        var IdentificacionesExamenes = new TblCatIdentificacionesExamenes
                //        {
                //            IdIdentificaciones = _idIdentificacion,
                //            IdIdentificacionesExamenes = id
                //        };

                //        _context.TblCatIdentificacionesExamenes.Add(IdentificacionesExamenes);
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
