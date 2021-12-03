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

namespace Aplicacion.Departamentos
{
    public class NuevoDepartamento
    {
        public class EjecutaDepartamento : IRequest
        {
            //public Guid IdDepartamento { get; set; }
            public Guid IdPais { get; set; }
            public string Descripcion { get; set; }
            public int Estado { get; set; }

            //public List<Guid> ListaDepartamentoesExamenes { get; set; }
        }
        public class EjecutaValidacionDepartamento : AbstractValidator<EjecutaDepartamento>
        {
            public EjecutaValidacionDepartamento()
            {
                RuleFor(x => x.Descripcion).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
                RuleFor(x => x.IdPais).NotEmpty();
                
            }
        }

        public class ManejadorDepartamento : IRequestHandler<EjecutaDepartamento>
        {
            private readonly netLisContext _context;
            public ManejadorDepartamento(netLisContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(EjecutaDepartamento request, CancellationToken cancellationToken)
            {
                Guid _idDepartamento = Guid.NewGuid();
                Debug.WriteLine(_idDepartamento);
                var Departamento = new TblCatDepartamento
                {
                    IdDepartamento = _idDepartamento,
                    Descripcion = request.Descripcion,
                    IdPais = request.IdPais,
                    Estado = 1
                   
                };

                _context.TblCatDepartamentos.Add(Departamento);

                //Agregando en tabla CursoInstructor
                //if (request.ListaDepartamentoesExamenes != null)
                //{
                //    foreach (var id in request.ListaDepartamentoesExamenes)
                //    {
                //        var DepartamentoesExamenes = new TblCatDepartamentoesExamenes
                //        {
                //            IdDepartamentoes = _idDepartamento,
                //            IdDepartamentoesExamenes = id
                //        };

                //        _context.TblCatDepartamentoesExamenes.Add(DepartamentoesExamenes);
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
