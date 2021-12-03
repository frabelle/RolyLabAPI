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

namespace Aplicacion.Nacionalidad
{
    public class NuevoNacionalidad
    {
        public class EjecutaNacionalidad : IRequest
        {
            //public Guid IdNacionalidad { get; set; }
            public string Descripcion { get; set; }
            

            //public List<Guid> ListaNacionalidadesExamenes { get; set; }
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
                Guid _idNacionalidad = Guid.NewGuid();
                Debug.WriteLine(_idNacionalidad);
                var Nacionalidad = new TblCatNacionalidad
                {
                    IdNacionalidad = _idNacionalidad,
                    Descripcion = request.Descripcion,
                    
                   
                };

                _context.TblCatNacionalidads.Add(Nacionalidad);

                //Agregando en tabla CursoInstructor
                //if (request.ListaNacionalidadesExamenes != null)
                //{
                //    foreach (var id in request.ListaNacionalidadesExamenes)
                //    {
                //        var NacionalidadesExamenes = new TblCatNacionalidadesExamenes
                //        {
                //            IdNacionalidades = _idNacionalidad,
                //            IdNacionalidadesExamenes = id
                //        };

                //        _context.TblCatNacionalidadesExamenes.Add(NacionalidadesExamenes);
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
