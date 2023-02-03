using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CteleportAssignment.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CteleportAssignment.RestApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : BaseApiController
    {

        [HttpGet()]
        public ActionResult Index()
        {
            return Ok("Hello, world!");
        }
        [HttpGet("GetJourneyLength")]
        public ActionResult GetJourneyLength(string from, string to)
        {

            var airportLogic = new AirportLogic(Uow);

            var distance = airportLogic.GetDistanceBetweenAirports(from, to);

            return Ok($"{distance} Miles");
        }
    }
}
