using FlightBooking.Data.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBook.Data.DomainModel
{
    public class Country : BaseDomainModel
    {
        [StringLength(20)]
        [Required]
        public string CountryCode { get; set; }
        [StringLength(100)]
        [Required]
        public string CountryName { get; set; }
    }
}
