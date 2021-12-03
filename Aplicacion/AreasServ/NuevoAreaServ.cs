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

namespace Aplicacion.AreasServ
{
    public class NuevoAreaServ
    {
        public class EjecutaAreaServ : IRequest
        {
            //public Guid IdAreaServ { get; set; }
            public string Descripcion { get; set; }
            public string DescripcionCorta { get; set; }
            public int Estado { get; set; }

            //public List<Guid> ListaAreaServesExamenes { get; set; }
        }
        public class EjecutaValidacionAreaServ : AbstractValidator<EjecutaAreaServ>
        {
            public EjecutaValidacionAreaServ()
            {
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
                RuleFor(x => x.DescripcionCorta).NotEmpty();
            }
        }

        public class ManejadorAreaServ : IRequestHandler<EjecutaAreaServ>
        {
            private readonly netLisContext _context;
            public ManejadorAreaServ(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaAreaServ request, CancellationToken cancellationToken)
            {
                Guid _idAreaServ = Guid.NewGuid();
                Debug.WriteLine(_idAreaServ);
                var AreaServ = new TblCatAreasServ
                {
                    IdAreaServ = _idAreaServ,
                    Descripcion = request.Descripcion,
                    Estado = 1,
                    DescripcionCorta = request.DescripcionCorta
                };

                _context.TblCatAreasServs.Add(AreaServ);

                //Agregando en tabla CursoInstructor
                //if (request.ListaAreaServesExamenes != null)
                //{
                //    foreach (var id in request.ListaAreaServesExamenes)
                //    {
                //        var AreaServesExamenes = new TblCatAreaServesExamenes
                //        {
                //            IdAreaServes = _idAreaServ,
                //            IdAreaServesExamenes = id
                //        };

                //        _context.TblCatAreaServesExamenes.Add(AreaServesExamenes);
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
