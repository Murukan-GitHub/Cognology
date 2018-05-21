using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using FlightBook.Data.Repository;
using FlightBook.Data.Repository.Interface;
using FlightBook.Application.Services;
using FlightBook.Application.Services;

namespace FlightBook.Application.Common
{
    class FactoryConfiguration
    {
        private static object locker = new object();

        public static void Configure()
        {
            lock (locker)
            {
                if (!Factory.HasBeenInitialised)
                {
                    UnityContainer container = Factory.Container;
                    container.RegisterType(typeof(IGeneralRepository<>), typeof(GeneralRepository<>));
                    container.RegisterType<IFlightQueryRepository, FlightQueryRepository>();
                    container.RegisterType<IFlightInfoService, FlightInfoService>(); 
                }
            }
        }
    }
}