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
  public  class PassengerDetail : BaseDomainModel
    { 
        [StringLength(50)]
        [Required]
        public string Firstname { get; set; }

        [StringLength(50)]
        [Required]
        public string Lastname { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string PassportNo { get; set; }

        [ForeignKey("Address")]
        public long AddressId { get; set; }
        public virtual Address Address { get; set; }

        [ForeignKey("BookingDetail")]
        public long BookingDetailId { get; set; }
        public virtual BookingDetail BookingDetail { get; set; }
    }
}
