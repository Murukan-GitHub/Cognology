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
   public  class BookingDetail:BaseDomainModel
    {
        public BookingDetail()
        {
            if (Passenger == null) { Passenger = new List<PassengerDetail>(); }
        }
        [ForeignKey("Schedule")]
        public long ScheduleID { get; set; }
        public virtual FlightSchedule Schedule { get; set; }

        public virtual IList<PassengerDetail> Passenger { get; set; }

    }
}
