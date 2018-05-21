using FlightBook.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FlightBook.WebApi.App_Start
{
    public static class UnityInjectionConfig
    {
        public static void Boot()
        {
            ApplicationBootstrapper.Boot();
        }
    }
}