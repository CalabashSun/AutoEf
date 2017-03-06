using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using Calabash.AutoEf.Core.Caching;
using Calabash.AutoEf.Core.Data;
using Calabash.AutoEf.Core.Fakes;
using Calabash.AutoEf.Core.Helper;
using Calabash.AutoEf.Core.Infrastructure;
using Calabash.AutoEf.Core.Infrastructure.DependencyManagement;
using Calabash.AutoEf.Data;
using Calabash.AutoEf.Framework.Mvc.Routes;

namespace Calabash.AutoEf.Web
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            //HTTP context and other related stuff
            builder.Register(c =>
                //register FakeHttpContext when HttpContext is not available
                HttpContext.Current != null ?
                (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
                (new FakeHttpContext("~/") as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerLifetimeScope();
            //web helper
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerLifetimeScope();

            //controllers

            builder.Register<IDbContext>(c => new CalabashObjectContext()).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());


            //cacheManager
            //redis 是否设置为启用
            if (false)
            {
                builder.RegisterType<RedisConnectionWrapper>().As<IRedisConnectionWrapper>().SingleInstance();
                builder.RegisterType<RedisCacheManager>()
                    .As<ICacheManager>()
                    .Named<ICacheManager>("cala_cache_static")
                    .InstancePerLifetimeScope();
            }
            else
            {
                builder.RegisterType<MemoryCacheManager>()
                    .As<ICacheManager>()
                    .Named<ICacheManager>("cala_cache_static")
                    .SingleInstance();
            }
            //builder.RegisterType<PerRequestCacheManager>().As<ICacheManager>().Named<ICacheManager>("cala_cache_per_request").InstancePerLifetimeScope();

            builder.RegisterType<RoutePublisher>().As<IRoutePublisher>().SingleInstance();

        }

        public int Order
        {
            get { return 0; }
        }
    }
}