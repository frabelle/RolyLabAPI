using Dominio.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Hospital
{
    public class ConsultaHospitalId
    {
        public class Unico : IRequest<TblCatHospital>
        {
            public Guid Id { get; set; }
        }

        public class ManejadorHospital : IRequestHandler<Unico, TblCatHospital>
        {
            private readonly netLisContext _context;
            public ManejadorHospital(netLisContext context)
            {
                _context = context;
            }
            public async Task<TblCatHospital> Handle(Unico request, CancellationToken cancellationToken)
            {
                var Hospital = await _context.TblCatHospitals.FindAsync(request.Id);
                return Hospital;
            }
        }
    }
}
