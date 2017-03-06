using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Calabash.AutoEf.Core.Infrastructure;
using Calabash.AutoEf.Core.Infrastructure.DependencyManagement;
using Calabash.AutoEf.Services.SCalabash;

namespace Calabash.AutoEf.Services
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<CalabashService>().As<ICalabashService>().InstancePerDependency();
        }

        public int Order
        {
            get { return 1; }
        }
    }
}
