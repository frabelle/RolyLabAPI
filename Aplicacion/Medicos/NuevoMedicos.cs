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

namespace Aplicacion.Medicos
{
    public class NuevoMedico
    {
        public class EjecutaMedico : IRequest
        {
            //public Guid IdMedico { get; set; }
            public string Nombres { get; set; }
            public string Apellidos { get; set; }
            public Guid IdtblCatSucursales { get; set; }
            public DateTime FechaCreacion { get; set; }
            public DateTime? FechaModificacion { get; set; }
            public DateTime? FechaEliminacion { get; set; }
            public Guid IdDepartamentoNac { get; set; }
            public Guid IdDepartamentoRes { get; set; }
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

            //public List<Guid> ListaMedicoesExamenes { get; set; }
        }
        public class EjecutaValidacionMedico : AbstractValidator<EjecutaMedico>
        {
            public EjecutaValidacionMedico()
            {
                RuleFor(x => x.Nombres).NotEmpty();
                RuleFor(x => x.Apellidos).NotEmpty();
                RuleFor(x => x.IdtblCatSucursales).NotEmpty();
                RuleFor(x => x.FechaCreacion).NotEmpty();
                RuleFor(x => x.IdDepartamentoNac).NotEmpty();
                RuleFor(x => x.IdDepartamentoRes).NotEmpty();
                RuleFor(x => x.IdPaisNac).NotEmpty();
                RuleFor(x => x.IdPaisRes).NotEmpty();
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
                Guid _idMedico = Guid.NewGuid();
                Debug.WriteLine(_idMedico);
                var Medico = new TblMedico
                {
                    IdTblMedico = _idMedico,
                    Nombres = request.Nombres,
                    Apellidos = request.Apellidos,
                    IdtblCatSucursales = request.IdtblCatSucursales,
                    FechaCreacion = DateTime.Now,
                    IdIdentificacion = request.IdIdentificacion,
                    IdEstadoCivil = request.IdEstadoCivil,
                    IdSexo = request.IdSexo,
                    IdPaisNac = request.IdPaisNac,
                    IdDepartamentoNac = request.IdDepartamentoNac,
                    IdPaisRes = request.IdPaisRes,
                    IdDepartamentoRes = request.IdDepartamentoRes,
                    NumIdentificacion = request.NumIdentificacion,
                    CodMinsa = request.CodMinsa,
                    FechaNac = request.FechaNac,
                    Email = request.Email,
                    Telefono = request.Telefono,
                    Estado = 1
                   
                };

                _context.TblMedicos.Add(Medico);

                //Agregando en tabla CursoInstructor
                //if (request.ListaMedicoesExamenes != null)
                //{
                //    foreach (var id in request.ListaMedicoesExamenes)
                //    {
                //        var MedicoesExamenes = new TblCatMedicoesExamenes
                //        {
                //            IdMedicoes = _idMedico,
                //            IdMedicoesExamenes = id
                //        };

                //        _context.TblCatMedicoesExamenes.Add(MedicoesExamenes);
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
