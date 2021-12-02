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

namespace Aplicacion.Sucursales
{
    public class NuevaSucursal
    {
        public class Ejecuta : IRequest
        {
            public Guid IdHospital { get; set; }
            public Guid IdDepartamento { get; set; }
            public Guid IdPais { get; set; }
            public string Descripcion { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }
            public string UrlLogo { get; set; }
            public int Estado { get; set; }
        }
        public class EjecutaValidacion : AbstractValidator<Ejecuta>
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.IdHospital).NotEmpty();
                RuleFor(x => x.IdDepartamento).NotEmpty();
                RuleFor(x => x.IdPais).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Direccion).NotEmpty();
                RuleFor(x => x.Telefono).NotEmpty();
                //RuleFor(x => x.UrlLogo).NotEmpty();
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
                Guid _idSucursal = Guid.NewGuid();
                Debug.WriteLine(_idSucursal);
                var sucursal = new TblCatSucursales
                {
                    IdSucursal = _idSucursal,
                    IdHospital = request.IdHospital,
                    IdDepartamento = request.IdDepartamento,
                    IdPais = request.IdPais,
                    Descripcion = request.Descripcion,
                    Direccion = request.Direccion,
                    UrlLogo = request.UrlLogo,
                    Telefono = request.Telefono,
                    Estado = 1
                };

                _context.TblCatSucursales.Add(sucursal);

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
                throw new Exception("No se pudo insertar sucursal");
            }
        }
    }
}
