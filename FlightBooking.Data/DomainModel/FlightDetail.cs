using FlightBooking.Data.DomainModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBook.Data.DomainModel
{
  public  class FlightDetail : BaseDomainModel
    {
        [StringLength(20)]
        [Required]
        public string FlightNo { get; set; }

        [StringLength(50)]
        [Required]
        public string FlightName { get; set; }

        public virtual  IList<FlightSchedule> Schedules { get; set; }
    }
}
