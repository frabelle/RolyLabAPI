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

namespace Aplicacion.TipoMuestra
{
    public class NuevoTipoMuestra
    {
        public class Ejecuta : IRequest
        {
            public Guid IdTipoMuestra { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }
        }
        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.IdTipoMuestra).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
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
                Guid _idTipoMuestra = Guid.NewGuid();
                Debug.WriteLine(_idTipoMuestra);
                var tipoMuestra = new TblCatTipoMuestra
                {
                    IdTipoMuestra = _idTipoMuestra,
                    Descripcion = request.Descripcion,
                    Estado = 1
                };

                _context.TblCatTipoMuestras.Add(tipoMuestra);

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
                throw new Exception("No se pudo insertar el tipo muestra");
            }
        }
    }
}
