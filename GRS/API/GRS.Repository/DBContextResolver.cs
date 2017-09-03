using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRS.Repository
{
    public static class DBContextResolver
    {


        private static IContainer _autofacContainer;
        private static ILifetimeScope _scope;

        public static void Config(IContainer autofacContainer)
        {
            _autofacContainer = autofacContainer;
            _scope = _autofacContainer.BeginLifetimeScope();
        }

        public static T CreateNewInstance<T> () where T : class
        {
            if (_scope == null) { return null; }
            return _scope.Resolve<T>();
        }

    }
}
