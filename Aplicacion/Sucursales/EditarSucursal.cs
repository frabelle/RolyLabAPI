using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Sucursales
{
    public class EditarSucursal
    {
        public class Ejecuta : IRequest
        {
            public Guid IdSucursal { get; set; }
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

            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var sucursal = await _context.TblCatSucursales.FindAsync(request.IdSucursal);
                if (sucursal == null)
                {
                    throw new Exception("La sucursal no existe");
                }

                sucursal.Descripcion = request.Descripcion ?? sucursal.Descripcion;
                sucursal.Direccion = request.Direccion ?? sucursal.Direccion;
                sucursal.Telefono = request.Telefono ?? sucursal.Telefono;
                sucursal.UrlLogo = request.UrlLogo ?? sucursal.UrlLogo;
                sucursal.Estado = 2;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar la sucursal");
            }
        }
    }
}
