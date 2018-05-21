using FlightBook.Application.Common;
using FlightBook.Application.Dto;
using FlightBook.Application.Mapper;
using FlightBook.Application.Services;
using FlightBook.Data.DatabaseContext;
using FlightBook.Data.DomainModel;
using FlightBook.Data.Repository;
using FlightBook.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBook.Application.Services
{
    public class FlightInfoService : IFlightInfoService
    {
        private IFlightQueryRepository _repository;
        private IGeneralRepository<FlightSchedule> _generalRepository;

        public FlightInfoService()
        {
            _repository = Factory.GetObject<IFlightQueryRepository>();
            _generalRepository = Factory.GetObject<IGeneralRepository<FlightSchedule>>();
        }

        public IList<FlightDetailDto> GellAllFlightInfo()
        {
            var result = (from p in _repository.GetAllFlightInfo()
                          select new FlightDetailDto
                          {
                              Flightno = p.Flight.FlightNo,
                              Starttime = p.StartTime,
                              Endtime = p.EndTime,
                              DeparterCity = p.ArrivalCity.Code,
                              AarrivalCity = p.DepartureCity.Code,
                              PassengerCapacity = p.MaximumPax
                          }).ToList<FlightDetailDto>();
            return result;
        }

        public bool CheckAvailability(DateTime startDate, DateTime endDate, int noOfPax)
        {
            var result = _repository.CheckAvailability(startDate, endDate, noOfPax);
            return result;
        }

        public IList<BookingDetailDto> SearchBookings(string passengerName, DateTime startDate, string arrivalCity, string departureCity, string flightNumber)
        {
            var result = _repository.SearchBookings(startDate, passengerName, arrivalCity, departureCity, flightNumber);

            var results = (from p in result
                           select new BookingDetailDto
                           {
                               Starttime = p.Schedule.StartTime,
                               Endtime = p.Schedule.EndTime,
                               DeparterCity = p.Schedule.ArrivalCity.Code,
                               AarrivalCity = p.Schedule.DepartureCity.Code
                           }).ToList<BookingDetailDto>();
            return results;
        }

        public bool MakeBooking(IList<PassengerDataDto> Entity,long ScheduleID)
        {
            var bookingDetail = new BookingDtoMapper(Entity, ScheduleID).SetModelProperties();

            DomainCrudFacade<BookingDetail> crudfacade = new DomainCrudFacade<BookingDetail>();
            crudfacade.Create(bookingDetail);
            return true;

            //return _repository.MakeBooking(ScheduleID,null);
        }
       
    }
}
