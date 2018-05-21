using FlightBook.Application;
using FlightBook.Application.Common;
using FlightBook.Application.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FlightBook.WebApi.Models
{
    public class FlightSearchBookingVM
    {

        private IFlightInfoService flightInfoService;
        public IList< BookingDetailDto> Entity;

        [JsonProperty("s_date")]
        public DateTime StartDate { get; set; }
        [JsonProperty("passenger_name")]
        public string PassengerName { get; set; }
        [JsonProperty("flight_number")]
        public string FlightNumber { get; set; }
        [JsonProperty("arrival_city")]
        public string ArrivalCity { get; set; }
        [JsonProperty("departure_city")]
        public string DepartureCity { get; set; }

        public FlightSearchBookingVM()
        {
            this.flightInfoService = Factory.GetObject<IFlightInfoService>();
            if (Entity == null)
                Entity = new List<BookingDetailDto>();
        }

        public async Task SearchBookings(string passengerName,DateTime startDate, string arrivalCity,string departureCity,string flightNumber)
        {
           Entity= await Task.Run(() => flightInfoService.SearchBookings(passengerName, startDate, arrivalCity, departureCity,flightNumber));
        }
    }
}