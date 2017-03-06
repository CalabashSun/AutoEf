using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Calabash.AutoEf.Core.Helper;

namespace Calabash.AutoEf.Web.Areas.Yacheng.Controllers
{
    public class CalaController : Controller
    {
        #region fileds

        private  readonly IWebHelper _webHelper;

        #endregion

        #region Ctor

        public CalaController(IWebHelper webHelper)
        {
            _webHelper = webHelper;
        }

        #endregion


        //
        // GET: /Yacheng/Cala/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sun()
        {
            var stringReulst=new StringBuilder();
            //1.验证是否为合法邮箱
            var isTrue = CommonHelper.IsValidEmail("924347693@qq.com");
            if (isTrue)
            {
                stringReulst.Append("是合法邮箱\r\n");
            }
            //2.验证是否为合法号码
            isTrue = CommonHelper.IsValidPhone("15295036872");
            if (isTrue)
            {
                stringReulst.Append("是合法号码\r\n");
            }
            //3.验证是否为合法ip
            isTrue = CommonHelper.IsValidIpAddress("218.94.124.234");
            if (isTrue)
                stringReulst.Append("是合法ip\r\n");

            //4.生成随机数
            var randomcode1 = CommonHelper.GenerateRandomDigitCode(5);

            stringReulst.Append(randomcode1 + "\r\n");

            //5.生成随机数2
            var randomcode2 = CommonHelper.GenerateRandomInteger(10000, 99999);
            stringReulst.Append(randomcode2 + "\r\n");

            //6.截取字符串
            var sub = CommonHelper.EnsureMaximumLength("sheishixiaochunhuo", 10, "...");
            stringReulst.Append(sub + "\r\n");

            //是合法邮箱 是合法号码 是合法ip 51405 52189 sheishi...


            return Content(stringReulst.ToString()+"\r\n");
        }

        public ActionResult Sun2()
        {
            var stringResult=new StringBuilder();
            var url1 = _webHelper.GetUrlReferrer();
            stringResult.Append(url1 + "\r\n");

            var ip1 = _webHelper.GetCurrentIpAddress();
            stringResult.Append(ip1 + "\r\n");


            var url2 = _webHelper.ModifyQueryString("http://www.baidu.com?sunz=cala", "cala=zyc", null);
            stringResult.Append(url2 + "\r\n");

            var url3 = _webHelper.RemoveQueryString("http://www.baidu.com?cala=sunz", "");
            stringResult.Append(url3 + "\r\n");


            return Content(stringResult + "\r\n");



        }



        public ActionResult Sun3()
        {
            return View();
        }
    }
}