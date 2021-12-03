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

namespace Aplicacion.ValoresNormales
{
    public class NuevoValoresNormales
    {
        public class Ejecuta : IRequest
        {
            public Guid IdValoresNormales { get; set; }
            public Guid IdExamen { get; set; }
            public Guid IdSexo { get; set; }
            public double RangoAlto { get; set; }
            public double RangoBajo { get; set; }
            public int Estado { get; set; }
        }
        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.IdExamen).NotEmpty();
                RuleFor(x => x.IdSexo).NotEmpty();
                RuleFor(x => x.RangoAlto).NotEmpty();
                RuleFor(x => x.RangoBajo).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly netLisContext _context;
            public Manejador (netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                Guid _idValorNormal = Guid.NewGuid();
                Debug.WriteLine(_idValorNormal);
                var valorNormal = new TblCatValoresNormales
                {
                    IdValoresNormales = _idValorNormal,
                    IdExamen = request.IdExamen,
                    IdSexo = request.IdSexo,
                    RangoAlto = request.RangoAlto,
                    RangoBajo = request.RangoBajo,
                    Estado = 1
                };

                _context.TblCatValoresNormales.Add(valorNormal);

                //Agregando en tabla CursoInstructor
                //if (request.ListaPerfilesExamenes != null)
                //{
                //    foreach (var id in request.ListaPerfilesExamenes)
                //    {
                //        var perfilesExamenes = new TblCatPerfilesExamenes
                //        {
                //            IdPerfiles = _idPerfil,
                //            IdPerfilesExamenes = id
                //        };

                //        _context.TblCatPerfilesExamenes.Add(perfilesExamenes);
                //    }
                //}
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar la unidad de medida");
            }
        }
    }
}
