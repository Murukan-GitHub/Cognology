using FlightBook.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBook.Application
{
    public static class ApplicationBootstrapper
    {
        public static void Boot()
        {
            //Configure the DI Container
            FactoryConfiguration.Configure();
        }
    }
}
