using FlightBook.Application.Common;
using FlightBook.Application.Dto;
using FlightBook.Application.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FlightBook.WebApi.Models
{
    public class MakeBookingVM
    {
        private IFlightInfoService flightInfoService;
        [JsonProperty("Passenger_details")]
        public IList<PassengerDataDto> Entity;

        [JsonProperty("schedule_id")]
        public long ScheduleID { get; set; }

        public MakeBookingVM()
        {
            this.flightInfoService = Factory.GetObject<IFlightInfoService>();
            if (Entity == null)
                Entity = new  List<PassengerDataDto>();
        }

        public async Task<bool> MakeBooking(IList<PassengerDataDto> Entity,long ScheduleID)
        {
            return await Task.Run(() => flightInfoService.MakeBooking(Entity,ScheduleID));
        }
    }
}