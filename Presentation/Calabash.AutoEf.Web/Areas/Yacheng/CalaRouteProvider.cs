using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Calabash.AutoEf.Framework;
using Calabash.AutoEf.Framework.Localization;
using Calabash.AutoEf.Framework.Mvc.Routes;

namespace Calabash.AutoEf.Web.Areas.Yacheng
{
    public class CalaRouteProvider:IRouteProvider
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapLocalizedRoute("Cala",
                "cala/xiaodaibi",
                new {controller = "Cala", action = "Sun"},
                new[] {"Calabash.AutoEf.Web.Areas.Yacheng.Controllers"});


            routes.MapLocalizedRoute("Cala2",
                "cala/xiaoshabi",
                new {controller = "Cala", action = "Sun2"},
                new[] {"Calabash.AutoEf.Web.Areas.Yacheng.Controllers"});
        }

        public int Priority {
            get { return 0; }
        }
    }
}