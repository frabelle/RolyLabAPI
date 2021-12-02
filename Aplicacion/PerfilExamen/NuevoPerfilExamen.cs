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

namespace Aplicacion.PerfilExamen
{
    public class NuevoPerfilExamen
    {
        public class Ejecuta : IRequest
        {
            public Guid IdExamen { get; set; }
            public Guid IdPerfiles { get; set; }
        }
        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.IdExamen).NotEmpty();
                RuleFor(x => x.IdPerfiles).NotEmpty();
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
                Guid _idPerfilExamen = Guid.NewGuid();
                Debug.WriteLine(_idPerfilExamen);
                var perfilExamen = new TblCatPerfilesExamenes
                {
                    IdPerfilesExamenes = _idPerfilExamen,
                    IdExamen = request.IdExamen,
                    IdPerfiles = request.IdPerfiles
                };

                _context.TblCatPerfilesExamenes.Add(perfilExamen);

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
                throw new Exception("No se pudo insertar el perfil de examen");
            }
        }
    }
}
