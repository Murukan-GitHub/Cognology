using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBook.Application
{
    public class FlightDetailDto
    {
        public string Flightno { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }
        public long PassengerCapacity { get; set; }
        public string DeparterCity { get; set; }
        public string AarrivalCity { get; set; }

    }
}
