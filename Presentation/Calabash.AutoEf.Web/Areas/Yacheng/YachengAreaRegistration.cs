using System.Web.Mvc;

namespace Calabash.AutoEf.Web.Areas.Yacheng
{
    public class YachengAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Yacheng";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Yacheng_default",
                "Yacheng/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}