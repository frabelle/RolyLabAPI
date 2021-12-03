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

namespace Aplicacion.Hospital
{
    public class NuevoHospital
    {
        public class EjecutaHospital : IRequest
        {
            //public Guid IdHospital { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }

            //public List<Guid> ListaHospitalesExamenes { get; set; }
        }
        public class EjecutaValidacionHospital : AbstractValidator<EjecutaHospital>
        {
            public EjecutaValidacionHospital()
            {
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
                
                
            }
        }

        public class ManejadorHospital : IRequestHandler<EjecutaHospital>
        {
            private readonly netLisContext _context;
            public ManejadorHospital(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaHospital request, CancellationToken cancellationToken)
            {
                Guid _idHospital = Guid.NewGuid();
                Debug.WriteLine(_idHospital);
                var Hospital = new TblCatHospital
                {
                    IdHospital = _idHospital,
                    Descripcion = request.Descripcion,
                    Estado = 1
                   
                };

                _context.TblCatHospitals.Add(Hospital);

                //Agregando en tabla CursoInstructor
                //if (request.ListaHospitalesExamenes != null)
                //{
                //    foreach (var id in request.ListaHospitalesExamenes)
                //    {
                //        var HospitalesExamenes = new TblCatHospitalesExamenes
                //        {
                //            IdHospitales = _idHospital,
                //            IdHospitalesExamenes = id
                //        };

                //        _context.TblCatHospitalesExamenes.Add(HospitalesExamenes);
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
