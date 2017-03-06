using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Calabash.AutoEf.Services.SCalabash;

namespace Calabash.AutoEf.Web.Controllers
{
    public class HomeController : Controller
    {
        #region fileds

        private readonly ICalabashService _calabashService;
        #endregion


        #region ctor

        public HomeController(ICalabashService calabashService)
        {
            _calabashService = calabashService;
        }

        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CalaName()
        {
            var name = _calabashService.CalabashName();
            return Content(name);
        }

        public ActionResult CalaListCache()
        {
            var info = _calabashService.GetAll();
            return Content(info[0].Grilfriend);
        }
    }
}