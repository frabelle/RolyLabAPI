using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.ValoresNormales
{
    public class EditarValoresNormales
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

            public Manejador(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var valorNormal = await _context.TblCatValoresNormales.FindAsync(request.IdValoresNormales);
                if (valorNormal == null)
                {
                    throw new Exception("La unidad de medida no existe");
                }
                /////////////////////////////////////////
                if (request.IdExamen == Guid.Empty)
                {
                    valorNormal.IdExamen = valorNormal.IdExamen;
                }
                else
                {
                    valorNormal.IdExamen = request.IdExamen;
                }
                /////////////////////////////////////////
                if (request.IdSexo == Guid.Empty)
                {
                    valorNormal.IdSexo = valorNormal.IdSexo;
                }
                else
                {
                    valorNormal.IdSexo = request.IdSexo;
                }
                /////////////////////////////////////////
                if (request.RangoAlto == 0)
                {
                    valorNormal.RangoAlto = valorNormal.RangoAlto;
                }
                else
                {
                    valorNormal.RangoAlto = request.RangoAlto;
                }
                /////////////////////////////////////////
                if (request.RangoBajo == 0)
                {
                    valorNormal.RangoBajo = valorNormal.RangoBajo;
                }
                else
                {
                    valorNormal.RangoBajo = request.RangoBajo;
                }
                /////////////////////////////////////////
                valorNormal.Estado = 2;

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar la unidad de medida");
            }
        }
    }
}
