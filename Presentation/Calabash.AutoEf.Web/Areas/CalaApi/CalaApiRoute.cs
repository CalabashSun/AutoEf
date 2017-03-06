using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace Calabash.AutoEf.Web.Areas.CalaApi
{
    public static class CalaApiRote
    {
        public static void Register(HttpConfiguration routes)
        {
            routes.MapHttpRoute(
                name:"HahaApi",
                routeTemplate:"xiaodaibi/{controller}/{action}/id",
                defaults: new {id=RouteParameter.Optional }
            );
        }
    }
}