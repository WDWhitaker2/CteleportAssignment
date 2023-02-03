using System;
using System.Collections.Generic;
using System.Text;

namespace CteleportAssignmentCTeleportAirportService.Models
{
    public class AirportModel
    {
        public string city_iata { get; set; }
        public Coordinate location { get; set; }
    }

    public class Coordinate
    {
        public string lon { get; set; }
        public string lat { get; set; }
    }
}
