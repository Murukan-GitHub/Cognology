using FlightBook.Data.DomainModel;
using FlightBook.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBook.Data.Repository.Interface
{
    public interface IFlightQueryRepository:IDisposable
    {
        IQueryable<BookingDetail> SearchBookings(Nullable<DateTime> startDate, string passengerName = "", string arrivalCity = "", string departureCity = "", string flightNumber = "");
        bool CheckAvailability(DateTime startDate, DateTime endDate, int noOfPax);
        IQueryable<FlightSchedule> GetAllFlightInfo();
        bool MakeBooking(long id,IList<PassengerDetail> passenger);
    }
}

