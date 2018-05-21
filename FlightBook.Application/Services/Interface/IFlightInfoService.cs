using FlightBook.Application.Dto;
using FlightBook.Data.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBook.Application.Services
{
   public interface IFlightInfoService
    {
        IList<BookingDetailDto> SearchBookings(string passengerName, DateTime startDate, string arrivalCity, string departureCity, string flightNumber);
        bool CheckAvailability(DateTime startDate, DateTime endDate, int noOfPax);
        IList<FlightDetailDto> GellAllFlightInfo();
        bool MakeBooking(IList<PassengerDataDto> dto ,long ScheduleID);
    }
}
