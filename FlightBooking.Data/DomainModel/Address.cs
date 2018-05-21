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
    public class Address : BaseDomainModel
    {

        [StringLength(100)]
        [Required]
        public string Street1 { get; set; }

        [StringLength(100)]
        public string Street2 { get; set; }

        [StringLength(20)]
        [Required]
        public string State { get; set; }

        [StringLength(10)]
        [Required]
        public string PostalCode { get; set; }

        [ForeignKey("Country")]
        public long CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
