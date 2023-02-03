using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CteleportAssignment.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CteleportAssignment.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        internal IUnitofWork Uow { get; set; }
        //public BaseApiController(IUnitofWork uow)
        //{
        //    Uow = uow;
        //}
        public BaseApiController()
        {
            Uow = new UnitOfWork();
        }


    }
}
