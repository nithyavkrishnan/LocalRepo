using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomFilter
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => throw new NotImplementedException();

        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
        {
            builder.RegisterType<MyFirstCustomFilter>().AsActionFilterFor<Controllers.HomeController>().InstancePerRequest();
        }
    }
}
    