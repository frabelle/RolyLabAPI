using Dominio.Model;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Medicos
{
    public class EditarMedico
    {
        public class EjecutaMedico : IRequest
        {
            public Guid IdTblMedico { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public Guid IdtblCatSucursales { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime? FechaModificacion { get; set; }
            public DateTime? FechaEliminacion { get; set; }
            public Guid IdMedicoNac { get; set; }
            public Guid IdMedicoRes { get; set; }
            public Guid IdPaisNac { get; set; }
            public Guid IdPaisRes { get; set; }
            public Guid IdIdentificacion { get; set; }
            public Guid IdEstadoCivil { get; set; }
            public Guid IdSexo { get; set; }
            public string NumIdentificacion { get; set; }
            public string CodMinsa { get; set; }
            public DateTime FechaNac { get; set; }
            public string Email { get; set; }
            public string Telefono { get; set; }
            public string UrlFoto { get; set; }
            public int Estado { get; set; }
        }

        public class EjecutaValidacionMedico : AbstractValidator<EjecutaMedico>
        {
            public EjecutaValidacionMedico()
            {
                RuleFor(x => x.Nombres).NotEmpty();
                RuleFor(x => x.Apellidos).NotEmpty();
                RuleFor(x => x.IdtblCatSucursales).NotEmpty();
                RuleFor(x => x.FechaModificacion).NotEmpty();
                //RuleFor(x => x.IdMedicoNac).NotEmpty();
                //RuleFor(x => x.IdMedicoRes).NotEmpty();
                //RuleFor(x => x.IdPaisNac).NotEmpty();
                //RuleFor(x => x.IdPaisRes).NotEmpty();
                RuleFor(x => x.IdIdentificacion).NotEmpty();
                RuleFor(x => x.IdEstadoCivil).NotEmpty();
                RuleFor(x => x.IdSexo).NotEmpty();
                RuleFor(x => x.NumIdentificacion).NotEmpty();
                RuleFor(x => x.CodMinsa).NotEmpty();
                RuleFor(x => x.FechaNac).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Telefono).NotEmpty();
                //RuleFor(x => x.UrlFoto).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
                
               
            }
        }

        public class ManejadorMedico : IRequestHandler<EjecutaMedico>
        {
            private readonly netLisContext _context;

            public ManejadorMedico(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaMedico request, CancellationToken cancellationToken)
            {
                var Medico = await _context.TblMedicos.FindAsync(request.IdTblMedico);
                if (Medico == null)
                {
                    throw new Exception("El Medico no existe");
                }

                Medico.Nombres = request.Nombres ?? Medico.Nombres;
                Medico.Apellidos = request.Apellidos ?? Medico.Apellidos;

                if (request.IdtblCatSucursales == Guid.Empty)
                {
                    Medico.IdtblCatSucursales = Medico.IdtblCatSucursales;
                }
                else
                {
                    Medico.IdtblCatSucursales = request.IdtblCatSucursales;
                }

                Medico.FechaModificacion = DateTime.Now;


                if (request.IdIdentificacion == Guid.Empty)
                {
                    Medico.IdIdentificacion = Medico.IdIdentificacion;
                }
                else
                {
                    Medico.IdIdentificacion = request.IdIdentificacion;
                }

                if (request.IdEstadoCivil == Guid.Empty)
                {
                    Medico.IdEstadoCivil = Medico.IdEstadoCivil;
                }
                else
                {
                    Medico.IdEstadoCivil = request.IdEstadoCivil;
                }

                if (request.IdSexo == Guid.Empty)
                {
                    Medico.IdSexo = Medico.IdSexo;
                }
                else
                {
                    Medico.IdSexo = request.IdSexo;
                }

                Medico.NumIdentificacion = request.NumIdentificacion ?? Medico.NumIdentificacion;
                Medico.CodMinsa = request.CodMinsa ?? Medico.CodMinsa;
                Medico.FechaNac = request.FechaNac;
                Medico.CodMinsa = request.CodMinsa ?? Medico.CodMinsa;
                Medico.Email = request.Email ?? Medico.Email;
                Medico.Telefono = request.Telefono ?? Medico.Telefono;
                Medico.NumIdentificacion = request.NumIdentificacion ?? Medico.NumIdentificacion;
                Medico.Estado = 2; 

                var resultado = await _context.SaveChangesAsync();
                if (resultado > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("Error al modificar el Medico");
            }
        }
    }
}
