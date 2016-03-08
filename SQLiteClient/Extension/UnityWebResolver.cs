
using Infrastructure.Dependances;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SQLiteClient
{
    public class UnityWebResolver : IDependencyResolver
    {
        protected IContainer _Container;

        public UnityWebResolver(IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            this._Container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return this._Container.Resoudre(serviceType);
            }
            catch (Exception )
            {
                return (object)null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this._Container.ResoudreTout(serviceType);
            }
            catch (Exception)
            {
                return (IEnumerable<object>)new List<object>();
            }
        }

        public void Dispose()
        {
            this._Container.Dispose();
        }
    }
}
