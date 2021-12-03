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

namespace Aplicacion.Paciente
{
    public class NuevoPaciente
    {
        public class EjecutaPaciente : IRequest
        {
            //public Guid IdPaciente { get; set; }
            public Guid IdIdentificacion { get; set; }
            public string NumIdentificacion { get; set; }
            public string NumInss { get; set; }
            public Guid IdEstadoCivil { get; set; }
            public string Email { get; set; }
            public Guid IdSexo { get; set; }
            public Guid IdPaisNac { get; set; }
            public Guid IdDepartamentoNac { get; set; }
            public Guid IdPaisRes { get; set; }
            public Guid IdDepartamentoRes { get; set; }
            public Guid IdTipoSangre { get; set; }
            public Guid IdProfesiones { get; set; }
            public string PrimerNombre { get; set; }
            public string SegundoNombre { get; set; }
            public string PrimerApellido { get; set; }
            public string SegundoApellido { get; set; }
            public DateTime FechaNac { get; set; }
            public string DireccionDomiciliar { get; set; }
            public string TelefonoDomiciliar { get; set; }
            public string TelefonoMovil { get; set; }
            public Guid Religion { get; set; }
            public string Activo { get; set; }
            public string Emabrazada { get; set; }
            public string Fallecido { get; set; }
            public int Estado { get; set; }

            //public List<Guid> ListaPacienteesExamenes { get; set; }
        }
        public class EjecutaValidacionPaciente : AbstractValidator<EjecutaPaciente>
        {
            public EjecutaValidacionPaciente()
            {
                RuleFor(x => x.PrimerNombre).NotEmpty();
                RuleFor(x => x.SegundoNombre).NotEmpty();
                RuleFor(x => x.PrimerApellido).NotEmpty();
                RuleFor(x => x.SegundoNombre).NotEmpty();
                RuleFor(x => x.IdIdentificacion).NotEmpty();
                RuleFor(x => x.IdEstadoCivil).NotEmpty();
                RuleFor(x => x.IdSexo).NotEmpty();
                RuleFor(x => x.IdPaisNac).NotEmpty();
                RuleFor(x => x.IdDepartamentoNac).NotEmpty();
                RuleFor(x => x.IdPaisRes).NotEmpty();
                RuleFor(x => x.IdDepartamentoRes).NotEmpty();
                RuleFor(x => x.IdTipoSangre).NotEmpty();
                RuleFor(x => x.IdProfesiones).NotEmpty();
                RuleFor(x => x.NumIdentificacion).NotEmpty();
                RuleFor(x => x.NumInss).NotEmpty();
                RuleFor(x => x.FechaNac).NotEmpty();
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.DireccionDomiciliar).NotEmpty();
                RuleFor(x => x.TelefonoDomiciliar).NotEmpty();
                RuleFor(x => x.TelefonoMovil).NotEmpty();
                RuleFor(x => x.Religion).NotEmpty();
                RuleFor(x => x.Activo).NotEmpty();
                RuleFor(x => x.Emabrazada).NotEmpty();
                RuleFor(x => x.Fallecido).NotEmpty();
                //RuleFor(x => x.UrlFoto).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();

            }
        }

        public class ManejadorPaciente : IRequestHandler<EjecutaPaciente>
        {
            private readonly netLisContext _context;
            public ManejadorPaciente(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaPaciente request, CancellationToken cancellationToken)
            {
                Guid _idPaciente = Guid.NewGuid();
                Debug.WriteLine(_idPaciente);
                var Paciente = new TblPaciente
                {
                    IdPaciente = _idPaciente,
                    IdIdentificacion = request.IdIdentificacion,
                    NumIdentificacion = request.NumIdentificacion,
                    NumInss = request.NumInss,
                    IdEstadoCivil = request.IdEstadoCivil,
                    Email = request.Email,
                    IdSexo = request.IdSexo,
                    IdPaisNac = request.IdPaisNac,
                    IdDepartamentoNac = request.IdDepartamentoNac,
                    IdPaisRes = request.IdPaisRes,
                    IdDepartamentoRes = request.IdDepartamentoRes,
                    IdTipoSangre = request.IdTipoSangre,
                    IdProfesiones = request.IdProfesiones,
                    PrimerNombre = request.PrimerNombre,
                    SegundoNombre = request.SegundoNombre,
                    PrimerApellido = request.PrimerApellido,
                    SegundoApellido = request.SegundoApellido,
                    FechaNac = request.FechaNac,
                    DireccionDomiciliar = request.DireccionDomiciliar,
                    TelefonoDomiciliar = request.TelefonoDomiciliar,
                    TelefonoMovil = request.TelefonoMovil,
                    Religion = request.Religion,
                    Activo = request.Activo,
                    Emabrazada = request.Emabrazada,
                    Fallecido = request.Fallecido,
                    Estado = 1
                   
                };

                _context.TblPacientes.Add(Paciente);

                //Agregando en tabla CursoInstructor
                //if (request.ListaPacienteesExamenes != null)
                //{
                //    foreach (var id in request.ListaPacienteesExamenes)
                //    {
                //        var PacienteesExamenes = new TblCatPacienteesExamenes
                //        {
                //            IdPacientees = _idPaciente,
                //            IdPacienteesExamenes = id
                //        };

                //        _context.TblCatPacienteesExamenes.Add(PacienteesExamenes);
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
