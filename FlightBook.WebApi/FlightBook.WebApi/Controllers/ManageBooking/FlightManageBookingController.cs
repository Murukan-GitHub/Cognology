using FlightBook.Application;
using FlightBook.Application.Dto;
using FlightBook.WebApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Description;
using static FlightBook.Application.Enumerations.Enumerations;

namespace FlightBook.WebApi.Controllers.ManageBooking
{

    public class FlightManageBookingController : ApiController
    {
        FlightDataVM model = new FlightDataVM();

        // GET api/<controller>
        [HttpGet]
        [Route("~/api/GetAllFlight")]
        public async Task<HttpResponseMessage> GetAllFlight()
        {
            await model.GetFlightInfo();
            if (model.Entity.Count > 0)
                return Request.CreateResponse(HttpStatusCode.OK, model.Entity);
            else
                return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/<controller>/5
        [HttpPost]
        [Route("~/api/CheckAvailability")]
        public async Task<HttpResponseMessage> CheckAvailability([FromBody]FlightCheckAvailabilityVM model)
        {
            JObject jsonresponse = GetJSONParams();
            FlightCheckAvailabilityVM flightSearchVM = new FlightCheckAvailabilityVM(); ;

            foreach (var item in jsonresponse)
            {
                string ritemkey = item.Key;
                if (String.Compare(ritemkey, ParamType.CheckAvailability.ToString(), true) == 0)
                    flightSearchVM = JsonConvert.DeserializeObject<FlightCheckAvailabilityVM>(item.Value.ToString());
            }

            var isAvailable = false;
            if (flightSearchVM != null)
                isAvailable = await flightSearchVM.CheckAvailability(flightSearchVM.StartDate, flightSearchVM.EndDate, flightSearchVM.NoOfPax);

            return Request.CreateResponse(HttpStatusCode.OK, isAvailable);
        }

        // POST api/<controller>/5
        [HttpPost]
        [Route("~/api/SearchBooking")]
        public async Task<HttpResponseMessage> SearchBooking([FromBody]FlightCheckAvailabilityVM model)
        {
            JObject jsonresponse = GetJSONParams();
            FlightSearchBookingVM flightSearchVM = new FlightSearchBookingVM(); ;

            foreach (var item in jsonresponse)
            {
                string ritemkey = item.Key;
                if (String.Compare(ritemkey, ParamType.SearchBooking.ToString(), true) == 0)
                    flightSearchVM = JsonConvert.DeserializeObject<FlightSearchBookingVM>(item.Value.ToString());
            }

            if (flightSearchVM != null)
                await flightSearchVM.SearchBookings(flightSearchVM.PassengerName, flightSearchVM.StartDate, flightSearchVM.ArrivalCity, flightSearchVM.DepartureCity, flightSearchVM.FlightNumber);

            if (flightSearchVM.Entity.Count > 0)
                return Request.CreateResponse(HttpStatusCode.OK, flightSearchVM.Entity);
            else
                return Request.CreateResponse(HttpStatusCode.OK, "No records found");
        }

        private static JObject GetJSONParams()
        {
            var path = HostingEnvironment.MapPath("~/Request_JSON/request.params.json");
            var jsonstring = System.IO.File.ReadAllText(path);
            JObject jsonresponse = JObject.Parse(jsonstring);
            return jsonresponse;
        }

        // POST api/<controller>
        [Route("~/api/MakeBooking/{id:int}")]
        public async Task<HttpResponseMessage> MakeBooking(int id,[FromBody]string value)
        {
            JObject jsonresponse = GetJSONParams();
            MakeBookingVM makeBookingVM = new MakeBookingVM(); ;

            foreach (var item in jsonresponse)
            {
                string ritemkey = item.Key;
                if (String.Compare(ritemkey, ParamType.MakeBooking.ToString(), true) == 0)
                {
                    makeBookingVM.ScheduleID =(long) item.Value["schedule_id"];
                    var p = item.Value["Passenger_details"].ToString();                   
                    JArray jsonarr = JArray.Parse(p) as JArray;
                    var c=jsonarr.Select(x => x).ToArray();
                    List<PassengerDataDto> items = jsonarr.Select(x => new PassengerDataDto
                    {
                        FirstName =x["passenger_first_name"].ToString(),
                        LastName = x["passenger_last_name"].ToString(),
                        AddressID =(long) x["address_id"],
                        DateOfBirth= Convert.ToDateTime( x["dob"]),
                        PassportNumber = Convert.ToString(x["passport_no"]),

                    }).ToList();
                    makeBookingVM.Entity =items;
                }                
            }
            var result = await makeBookingVM.MakeBooking(makeBookingVM.Entity, makeBookingVM.ScheduleID);
            
            return Request.CreateResponse(HttpStatusCode.OK,result);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}