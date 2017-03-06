using System;
using System.IO;
using System.Linq;

namespace Calabash.AutoEf.Core.Helper
{
    public class HtmlHelper
    {
        #region Method
        /// <summary>
        /// 判断访问设备 wechat:微信 web手机浏览器 pc：电脑
        /// </summary>
        /// <param name="userAgent"></param>
        /// <returns></returns>
        public static string FacilityType(string userAgent)
        {
            string[] mobileAgents = { "iphone", "android", "phone",
                                        "mobile", "wap", "netfront", "mqq","ucweb",
                                        "java", "opera mobi",
                                        "opera mini", "ucweb",
                                        "windows ce", "symbian", "series",
                                        "webos", "sony", "blackberry",
                                        "dopod", "nokia", "samsung",
                                        "palmsource", "xda", "pieplus",
                                        "meizu", "midp", "cldc",
                                        "motorola", "foma","docomo",
                                        "up.browser", "up.link", "blazer",
                                        "helio", "hosin", "huawei", "novarra",
                                        "coolpad", "webos",
                                        "techfaith", "palmsource",
                                        "alcatel","amoi", "ktouch",
                                        "nexian", "ericsson", "philips",
                                        "sagem", "wellcom", "bunjalloo", "maui",
                                        "smartphone", "iemobile", "spice", "bird",
                                        "zte-", "longcos", "pantech", "gionee", "portalmmm",
                                        "jig browser", "hiptop", "benq", "haier", "^lct",
                                        "320x320", "240x320", "176x220",  "w3c ", "acs-",
                                        "alav", "alca", "amoi", "audi", "avan", "benq",
                                        "bird", "blac", "blaz", "brew", "cell", "cldc",
                                        "cmd-", "dang", "doco", "eric", "hipt", "inno", "ipaq",
                                        "java", "jigs", "kddi", "keji", "leno", "lg-c", "lg-d",
                                        "lg-g", "lge-", "maui", "maxo", "midp", "mits","mmef",
                                        "mobi", "mot-", "moto", "mwbp", "nec-", "newt", "noki", "oper",
                                        "palm", "pana", "pant", "phil", "play", "port", "prox", "qwap",
                                        "sage", "sams", "sany", "sch-", "sec-", "send", "seri", "sgh-", "shar",
                                        "sie-", "siem", "smal", "smar", "sony", "sph-", "symb", "t-mo","teli",
                                        "tim-", "tosh", "tsm-", "upg1", "upsi", "vk-v", "voda", "wap-", "wapa", "wapi", "wapp", "wapr", "webc", "winw", "winw", "xda", "xda-", "Googlebot-Mobile" };
            // userAgent.ToString().ToLower()
            WriteLog(userAgent.ToString().ToLower());
            var istrue = mobileAgents.Any(t => userAgent.ToString().ToLower().IndexOf(t, StringComparison.Ordinal) >= 0);

            if (userAgent.ToLower().Contains("micromessenger"))
                return "Wechat";
            else if (istrue)
                return "Web";
            else
                return "PC";
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="strLog"></param>
        public static void WriteLog(string strLog)
        {
            string sFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\log\\" + DateTime.Now.ToString("yyyyMMdd");
            string sFileName = DateTime.Now.ToString("ddHH") + ".log";
            sFileName = sFilePath + "\\" + sFileName; //文件的绝对路径
            if (!Directory.Exists(sFilePath))//验证路径是否存在
            {
                Directory.CreateDirectory(sFilePath);
                //不存在则创建
            }
            FileStream fs;
            StreamWriter sw;
            if (System.IO.File.Exists(sFileName))
            //验证文件是否存在，有则追加，无则创建
            {
                fs = new FileStream(sFileName, FileMode.Append, FileAccess.Write);
            }
            else
            {
                fs = new FileStream(sFileName, FileMode.Create, FileAccess.Write);
            }
            sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + "   ---   " + strLog);
            sw.Close();
            fs.Close();
        }

        #endregion
    }
}
