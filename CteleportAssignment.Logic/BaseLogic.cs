using CteleportAssignment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CteleportAssignment.Logic
{
    public abstract class BaseLogic
    {
        internal IUnitofWork Uow { get; set; }
        public BaseLogic(IUnitofWork uow)
        {
            Uow = uow;
        }
    }
}
