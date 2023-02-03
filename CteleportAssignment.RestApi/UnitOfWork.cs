using CteleportAssignment.Domain.Interfaces;
using CteleportAssignmentCTeleportAirportService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CteleportAssignment.RestApi
{
    public class UnitOfWork : IUnitofWork
    {
        public UnitOfWork()
        {
            AirportRepo = new CtAirportRepository();
        }
        public IAirportRepository AirportRepo { get ; set; }
    }
}
