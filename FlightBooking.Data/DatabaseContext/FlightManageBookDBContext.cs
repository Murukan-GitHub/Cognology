using FlightBook.Data.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBook.Data.DatabaseContext
{
    public class FlightManageBookDBContext : DbContext
    {
        public FlightManageBookDBContext()
            : base("name=FlightBookingMangeDB")
        {
            Database.SetInitializer(new DBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<FlightSchedule>()
                        .HasRequired(o => o.ArrivalCity)
                        .WithMany()
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<FlightSchedule>()
                        .HasRequired(o => o.DepartureCity)
                        .WithMany()
                        .WillCascadeOnDelete(false);
        }

        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<FlightDetail> FlightDetail { get; set; }
        public virtual DbSet<PassengerDetail> PassengerDetail { get; set; }
        public virtual DbSet<FlightSchedule> FlightSchedule { get; set; }
        public virtual DbSet<BookingDetail> BookingDetail { get; set; }
    }
}
