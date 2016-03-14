using Infrastructure.Dependances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;


[assembly: PreApplicationStartMethod(typeof(SQLiteClient.BootStrapper), "Start")]

namespace SQLiteClient
{
    public static class BootStrapper
    {
        public static void Start()
        {
            //Infrastructure.Dependances.DependanceFactory.Instance.ContainerActuel.RegisterInstance<IApplicationUserStore, ApplicationUserStore>();
            //IoCFactory.Instance.CurrentContainer.RegisterType(typeof(ApplicationUserManager));
            //IoCFactory.Instance.CurrentContainer.RegisterType(typeof(ApplicationSignInManager));
            //IoCFactory.Instance.CurrentContainer.RegisterType(typeof(EmailManagementServices));
            //IoCFactory.Instance.CurrentContainer.RegisterInstance<IAuthenticationManager>(c => HttpContext.Current.GetOwinContext().Authentication);
            DependencyResolver.SetResolver((IDependencyResolver)new UnityWebResolver(DependanceFactory.Instance.ContainerActuel));
        }

        public static void Stop()
        {
        }

        private static void RegisterControllers(IContainer _currentContainer)
        {
            IEnumerable<Type> controllerTypes = Assembly.GetExecutingAssembly().GetExportedTypes().Where(x => typeof(IController).IsAssignableFrom(x));
            foreach (Type type in controllerTypes)
            {
                _currentContainer.EnregisterType(type);
            }
        }
    }
}