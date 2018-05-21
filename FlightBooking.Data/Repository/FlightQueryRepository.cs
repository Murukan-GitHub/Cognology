using FlightBook.Data.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightBook.Data.Repository.Interface;
using FlightBook.Data.Repository;
using System.Data.Entity;

namespace FlightBook.Data.Repository
{
    public class FlightQueryRepository : GeneralRepository<BookingDetail>, IFlightQueryRepository
    {
        protected DbSet<BookingDetail> thisentity = null;
        public FlightQueryRepository() : base()
        {
            thisentity = base.entity;
        }

        public bool CheckAvailability(DateTime startDate, DateTime endDate, int noOfPax)
        {

            var thisSchedleEntity = db.Set<FlightSchedule>();
            var AvailableSlots = (from p in thisSchedleEntity.Where(o => o.StartTime >= startDate && o.EndTime <= endDate).AsQueryable()
                                  select new { ID = p.Id, Pax = p.MaximumPax }).ToList();

            long[] _ids = AvailableSlots.Select(a => a.ID).ToArray();           
            long BookedPax = thisentity.AsQueryable().Where(x=>_ids.Contains(x.ScheduleID)).Select(e => e.Passenger).ToList().Count();
            
            return (AvailableSlots.Sum(o => o.Pax) - BookedPax) > 0;

        }

        public IQueryable<BookingDetail> SearchBookings(Nullable<DateTime> startDate, string passengerName = "", string arrivalCity = "", string departureCity = "", string flightNumber = "")
        {
            var result = thisentity.Include(e => e.Passenger).Include(o => o.Schedule)
                         .AsQueryable();
            if (startDate != null)
                result = result.Where(o => o.Schedule.StartTime >= startDate).AsQueryable();

            if (!string.IsNullOrEmpty(passengerName))
                result = result.Where(o => (o.Passenger.Select(e => e.Firstname + " " + e.Lastname)).Contains(passengerName)).AsQueryable();

            if (!string.IsNullOrEmpty(arrivalCity))
                result = result.Where(o => o.Schedule.ArrivalCity.Code == arrivalCity).AsQueryable();

            if (!string.IsNullOrEmpty(flightNumber))
                result = result.Where(o => o.Schedule.Flight.FlightNo == flightNumber).AsQueryable();

            return result;
        }

        IQueryable<FlightSchedule> IFlightQueryRepository.GetAllFlightInfo()
        {
            var thisentity = db.Set<FlightSchedule>();
            var result = thisentity.Include(e => e.Flight).Include(o => o.DepartureCity).Include(a => a.ArrivalCity)
                        .AsQueryable();

            return result;
        }

        public bool MakeBooking(long scheduleId, IList<PassengerDetail> passenger)
        {
            IList<PassengerDetail> defaultPassengerDetail = new List<PassengerDetail>();
            defaultPassengerDetail.Add(new PassengerDetail() {Firstname = "David", Lastname = "Parker", DateOfBirth = new DateTime(1966, 1, 1), PassportNo = "123456", AddressId = 1 });
            defaultPassengerDetail.Add(new PassengerDetail() { Firstname = "Mark", Lastname = "Parker", DateOfBirth = new DateTime(1956, 1, 1), PassportNo = "525666", AddressId = 2 });

            var passenerDetail = new List<PassengerDetail>();
            passenerDetail.AddRange(defaultPassengerDetail);

            var schedule = new FlightSchedule();
            var thisScheduleEntity = db.Set<FlightSchedule>();

            schedule = thisScheduleEntity.Find(1);

            var bookingDetail = new BookingDetail() { Passenger= passenerDetail, Schedule = schedule };
            base.Add(bookingDetail);
            base.Save();
            return true;

        }
    }
}
