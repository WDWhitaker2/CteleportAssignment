using System;
using System.Collections.Generic;
using System.Text;

namespace CteleportAssignment.Domain.Interfaces
{
    public interface IUnitofWork
    {
        IAirportRepository AirportRepo { get;set;}
    }
}
