using Dominio.Model;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aplicacion.Hospital
{
    public class HospitalConsulta
    {

        public class EjecutaHospital : IRequest<List<TblCatHospital>> { }

        public class ManejadorHospital : IRequestHandler<EjecutaHospital, List<TblCatHospital>>
        {
            private readonly netLisContext _context;
            public ManejadorHospital(netLisContext context)
            {
                _context = context;
            }
            public async Task<List<TblCatHospital>> Handle(EjecutaHospital request, CancellationToken cancellationToken)
            {
                var hospital = await _context.TblCatHospitals.ToListAsync();
                return hospital;
            }
        }
    }
}
