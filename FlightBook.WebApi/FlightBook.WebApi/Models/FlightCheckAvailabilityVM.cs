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
    public class FlightCheckAvailabilityVM
    {
        private IFlightInfoService flightInfoService;
        [JsonProperty("s_date")]
        public DateTime StartDate { get; set; }
        [JsonProperty("e_date")]
        public DateTime EndDate { get; set; }
        [JsonProperty("no_of_pax")]
        public int NoOfPax { get; set; }

        public FlightCheckAvailabilityVM()
        {
            this.flightInfoService = Factory.GetObject<IFlightInfoService>();
        }

        public Task< bool> CheckAvailability(DateTime startDate, DateTime endDate, int noOfPax)
        {
            return Task.Run(() => flightInfoService.CheckAvailability(startDate, endDate, noOfPax));
        }
    }
}