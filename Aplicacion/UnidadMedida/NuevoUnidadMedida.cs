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

namespace Aplicacion.UnidadMedida
{
    public class NuevoUnidadMedida
    {
        public class Ejecuta : IRequest
        {
            public Guid IdUnidadMedidas { get; set; }
            public string UnidadMedida { get; set; }
            public int? Estado { get; set; }
        }
        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.UnidadMedida).NotEmpty();
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
                Guid _idUnidadMedida = Guid.NewGuid();
                Debug.WriteLine(_idUnidadMedida);
                var unidadMedida = new TblCatUnidadMedida
                {
                    IdUnidadMedidas = _idUnidadMedida,
                    Estado = 1
                };

                _context.TblCatUnidadMedidas.Add(unidadMedida);

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
