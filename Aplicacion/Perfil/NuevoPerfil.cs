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

namespace Aplicacion.Perfil
{
    public class NuevoPerfil
    {
        public class EjecutaPerfil : IRequest
        {
            public string Descripcion { get; set; }
            public int Estado { get; set; }

            public List<Guid> ListaPerfilesExamenes { get; set; }
        }
        public class EjecutaValidacionPerfil : AbstractValidator<EjecutaPerfil>
        {
            public EjecutaValidacionPerfil()
            {
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
            }
        }

        public class ManejadorPerfil : IRequestHandler<EjecutaPerfil>
        {
            private readonly netLisContext _context;
            public ManejadorPerfil(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaPerfil request, CancellationToken cancellationToken)
            {
                Guid _idPerfil = Guid.NewGuid();
                Debug.WriteLine(_idPerfil);
                var perfil = new TblCatPerfiles
                {
                    IdPerfiles = _idPerfil,
                    Descripcion = request.Descripcion,
                    Estado = request.Estado
                };

                _context.TblCatPerfiles.Add(perfil);

                //Agregando en tabla CursoInstructor
                if (request.ListaPerfilesExamenes != null)
                {
                    foreach (var id in request.ListaPerfilesExamenes)
                    {
                        var perfilesExamenes = new TblCatPerfilesExamenes
                        {
                            IdPerfiles = _idPerfil,
                            IdPerfilesExamenes = id
                        };

                        _context.TblCatPerfilesExamenes.Add(perfilesExamenes);
                    }
                }
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
