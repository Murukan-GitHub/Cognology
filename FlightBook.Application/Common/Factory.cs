using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;

namespace FlightBook.Application.Common
{
    public class Factory
    {
        private static object locker = new object();


        private static UnityContainer innerContainer = null;


        public static bool HasBeenInitialised
        {
            get { return innerContainer != null; }
        }

        public static void Initialise()
        {
            lock (locker)
            {
                if (!HasBeenInitialised)
                {
                    innerContainer = new UnityContainer();
                }
            }
        }

        public static void Destroy()
        {
            lock (locker)
            {
                if (innerContainer != null)
                {
                    innerContainer.Dispose();
                    innerContainer = null;
                }
            }
        }

        public static T GetObject<T>(params object[] args)
            where T : class
        {
            return Container.Resolve<T>();
        }
        public static T GetObjectByName<T>(T args)
            where T : class
        {
            return Container.Resolve<T>();
        }
        public static void RegisterPerThreadInstance<T>(T instance)
        {
            lock (locker)
            {
                Container.RegisterInstance<T>(
                    instance,
                    new PerThreadLifetimeManager()
                    );

            }
        }

        public static void RegisterPerThreadInstance<T>(T instance, string name)
        {
            lock (locker)
            {
                Container.RegisterInstance<T>(
                    name,
                    instance,
                    new PerThreadLifetimeManager()
                    );
            }
        }

        public static UnityContainer Container
        {
            get
            {
                Initialise();
                return innerContainer;
            }
        }
    }
}
