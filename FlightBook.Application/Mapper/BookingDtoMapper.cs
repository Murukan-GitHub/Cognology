using FlightBook.Application.Common;
using FlightBook.Application.Dto;
using FlightBook.Data.DomainModel;
using FlightBook.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBook.Application.Mapper
{
    public class BookingDtoMapper
    {
        public IList<PassengerDataDto> Dto { get; set; }
        public long ScheduleID { get; set; }
        public BookingDtoMapper(IList<PassengerDataDto> Dto, long ScheduleID)
        {
            this.Dto = Dto;
            this.ScheduleID = ScheduleID;

        }

        IGeneralRepository<FlightSchedule> _generalRepository;

        BookingDetail DomainModel = new BookingDetail();
        public BookingDetail SetModelProperties()
        {
            _generalRepository = Factory.GetObject<IGeneralRepository<FlightSchedule>>();
            IGeneralRepository<Address> _AddressRepository = Factory.GetObject<IGeneralRepository<Address>>();

            DomainModel.Schedule = _generalRepository.LoadById(ScheduleID);

            DomainModel.Passenger = Dto.Select(o => new PassengerDetail()
            {
                Address = _AddressRepository.LoadById(o.AddressID),
                DateOfBirth = o.DateOfBirth,
                Firstname = o.FirstName,
                Lastname = o.LastName,
                PassportNo = o.PassportNumber
            }).ToList();

            return DomainModel;
        }

    }
}

