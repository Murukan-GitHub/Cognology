using FlightBook.Application;
using FlightBook.Application.Common;
using FlightBook.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FlightBook.WebApi.Models
{
    public class FlightDataVM
    {
        private IFlightInfoService flightInfoService;
        public IList<FlightDetailDto> Entity;

        public FlightDataVM()
        {
            this.flightInfoService = Factory.GetObject<IFlightInfoService>();
        }

        public async Task GetFlightInfo()
        {
            Entity = await Task.Run(() => flightInfoService.GellAllFlightInfo());
        }

    }
}