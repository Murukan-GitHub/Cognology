using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace FlightBook.Application.Dto
{
  public  class PassengerDataDto
    {
        [JsonProperty("passenger_first_name")]
        public string FirstName { get; set; }
        [JsonProperty("passenger_last_name")]
        public string LastName { get; set; }
        [JsonProperty("passport_no")]
        public string PassportNumber { get; set; }
        [JsonProperty("address_id")]
        public long AddressID { get; set; }
        [JsonProperty("dob")]
        public DateTime DateOfBirth { get; set; }
    }
}
