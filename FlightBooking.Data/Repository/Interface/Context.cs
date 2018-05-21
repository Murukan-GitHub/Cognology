using FlightBook.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Data.Repository.Interface
{
  public abstract  class Context
    {
        protected FlightManageBookDBContext db = null;
        public Context()
        {
            if (db == null)
                db = new FlightManageBookDBContext();
    }
    
    }
}
