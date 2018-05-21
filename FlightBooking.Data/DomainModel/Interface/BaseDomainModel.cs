using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Data.DomainModel
{
    public abstract class BaseDomainModel
    {
        [Key]
        public long Id { get; set; }

        public DateTime CreatedDate
        {
            get
            {
                return DateTime.Now;
            }
            set{            }
        }
        
    }
}
