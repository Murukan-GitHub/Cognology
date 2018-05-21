using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightBook.Application;
using FlightBook.Application.Common;
using FlightBook.Application.Services;
using FlightBook.Data.DatabaseContext;
using FlightBook.Data.DomainModel;
using FlightBook.Data.Repository;


namespace FlightBook.ConsoleApp
{
    class Program
    {

        static void Main(string[] args)
        {
            ApplicationBootstrapper.Boot();
            Test t = new Test();
            t.TestMethod();
        }

        public class Test
        {
            private  IFlightInfoService FlightInfoService;
            //private readonly IFlightQueryRepository _generalRepository2;
            public Test()
            {
                this.FlightInfoService = Factory.GetObject<IFlightInfoService>();
            }
            public void TestMethod()
            {
                using (FlightManageBookDBContext conetxt = new FlightManageBookDBContext())
                {
                    //5 var contry = _generalRepository.CheckAvailability( DateTime.MinValue,DateTime.MinValue,10).ToList();
                    //  var res = _generalRepository.SearchBookings( DateTime.MinValue,"", "","","").ToList();
                    var res = FlightInfoService.CheckAvailability(new DateTime(2018,01,05,01,00,00 ), new DateTime(2018, 01, 08, 01, 00,00),3);

                    IList<PassengerDetail> defaultPassengerDetail = new List<PassengerDetail>();
                    defaultPassengerDetail.Add(new PassengerDetail() { Id = 1, Firstname = "David", Lastname = "Parker", DateOfBirth = new DateTime(1966, 1, 1), PassportNo = "123456", AddressId = 1 });
                    defaultPassengerDetail.Add(new PassengerDetail() { Id = 2, Firstname = "Mark", Lastname = "Parker", DateOfBirth = new DateTime(1956, 1, 1), PassportNo = "525666", AddressId = 2 });
                    defaultPassengerDetail.Add(new PassengerDetail() { Id = 3, Firstname = "Taylor", Lastname = "Parker", DateOfBirth = new DateTime(1980, 1, 1), PassportNo = "633533", AddressId = 2 });

                    IList<BookingDetail> defaultBookingDetail = new List<BookingDetail>();
                    defaultBookingDetail.Add(new BookingDetail() { Id = 1, ScheduleID = 1, Passenger = defaultPassengerDetail });


                    //context.BookingDetail.AddRange(defaultBookingDetail);

                }
            }
        }
    }
}
