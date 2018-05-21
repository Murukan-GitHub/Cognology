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
  public  class City : BaseDomainModel
    {
        [StringLength(10)]
        [Required]
        public string Code { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [ForeignKey("Country")]
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }

        //[InverseProperty("ArrivalCity")]
        //public ICollection<FlightSchedule> ArrivalFlights { get; set; }

        //[InverseProperty("DepartureCity")]
        //public ICollection<FlightSchedule> DepartureFlights { get; set; }
    }
}
