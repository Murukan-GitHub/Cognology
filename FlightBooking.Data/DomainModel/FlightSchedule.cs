using FlightBooking.Data.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBook.Data.DomainModel
{
  public  class FlightSchedule : BaseDomainModel
    {
        [ForeignKey("Flight")]
        public long FlightId { get; set; }
        public virtual FlightDetail Flight { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [ForeignKey("ArrivalCity")]
        public long ArrivalCityID { get; set; }
        public virtual City ArrivalCity { get; set; }

        [ForeignKey("DepartureCity")]
        public long DebartureCityID { get; set; }
        public virtual City DepartureCity { get; set; }

        public long MaximumPax { get; set; }
    }
}
