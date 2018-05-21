using FlightBook.Data.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBook.Data.DatabaseContext
{
  internal   class DBInitializer : CreateDatabaseIfNotExists<FlightManageBookDBContext>
    {
        protected override void Seed(FlightManageBookDBContext context)
        {
            IList<Country> defaultCountries = new List<Country>();
            defaultCountries.Add(new Country() {Id=1, CountryCode = "AU", CountryName = "Australia" });
            defaultCountries.Add(new Country() { Id = 2, CountryCode = "NZ", CountryName = "New Zealand" });
            defaultCountries.Add(new Country() { Id = 3, CountryCode = "USA", CountryName = "America" });
            defaultCountries.Add(new Country() { Id = 4, CountryCode = "SL", CountryName = "Sri Lanka" });
            defaultCountries.Add(new Country() { Id = 5, CountryCode = "IND", CountryName = "India" });

            context.Country.AddRange(defaultCountries);

            IList<City> defaultCities = new List<City>();
            defaultCities.Add(new City() { Id = 1, Code= "MEL", Name = "Melbourne" ,CountryId=1});
            defaultCities.Add(new City() { Id = 2, Code = "WEL", Name = "Wellington",CountryId=2 });
            defaultCities.Add(new City() { Id = 3, Code = "COL", Name = "Colombo",CountryId=4 });
            defaultCities.Add(new City() { Id = 4, Code = "MUB",Name="Mumbai",CountryId=5 });

            context.City.AddRange(defaultCities);

            IList<Address> defaultAddress = new List<Address>();
            defaultAddress.Add(new Address() { Id = 1, PostalCode = "3111", Street1 = "1 Melbourne st", State ="Vic",CountryId=1  });
            defaultAddress.Add(new Address() { Id = 2, PostalCode = "3000", Street1 = "2 Wellington rd ", State = "NSW", CountryId = 1 });
            defaultAddress.Add(new Address() { Id = 3, PostalCode = "3000", Street1 = "2 Noble Park", State = "Vic", CountryId = 1 });

            context.Address.AddRange(defaultAddress);           

            IList<FlightDetail> defaultFlightDetail = new List<FlightDetail>();
            defaultFlightDetail.Add(new FlightDetail() { Id = 1, FlightName="Qantas Airways",FlightNo="Q12345" });
            defaultFlightDetail.Add(new FlightDetail() { Id = 2, FlightName = "Singapore Airways", FlightNo = "SQ121212" });
            defaultFlightDetail.Add(new FlightDetail() { Id = 3, FlightName = "Malaysian Airways", FlightNo = "M222222" });

            context.FlightDetail.AddRange(defaultFlightDetail);

            IList<FlightSchedule> defaultFlightSchedule = new List<FlightSchedule>();
            defaultFlightSchedule.Add(new FlightSchedule() { Id = 1, ArrivalCityID=3,DebartureCityID=1,FlightId=1,MaximumPax=200, StartTime=new DateTime (2018,01,01,7,00,00), EndTime = new DateTime(2018, 01, 02, 7, 00, 00) });
            defaultFlightSchedule.Add(new FlightSchedule() { Id = 2, ArrivalCityID = 1, DebartureCityID = 2, FlightId = 2, MaximumPax = 240, StartTime = new DateTime(2018, 01, 05, 7, 00, 00), EndTime = new DateTime(2018, 01, 06, 7, 00, 00) });
            
            context.FlightSchedule.AddRange(defaultFlightSchedule);

            IList<PassengerDetail> defaultPassengerDetail = new List<PassengerDetail>();
            defaultPassengerDetail.Add(new PassengerDetail() { Id = 1, Firstname = "David", Lastname = "Parker", DateOfBirth = new DateTime(1966, 1, 1), PassportNo = "123456", AddressId = 1 });
            defaultPassengerDetail.Add(new PassengerDetail() { Id = 2, Firstname = "Mark", Lastname = "Parker", DateOfBirth = new DateTime(1956, 1, 1), PassportNo = "525666", AddressId = 2 });
            defaultPassengerDetail.Add(new PassengerDetail() { Id = 3, Firstname = "Taylor", Lastname = "Parker", DateOfBirth = new DateTime(1980, 1, 1), PassportNo = "633533", AddressId = 2 });

            IList<BookingDetail> defaultBookingDetail = new List<BookingDetail>();
            defaultBookingDetail.Add(new BookingDetail() { Id = 1,ScheduleID=1,Passenger= defaultPassengerDetail });


            context.BookingDetail.AddRange(defaultBookingDetail);

            base.Seed(context);
        }
    }
}
