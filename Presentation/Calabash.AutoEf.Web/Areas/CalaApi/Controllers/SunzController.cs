using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Calabash.AutoEf.Web.Areas.CalaApi.Controllers
{
    public class SunzController : ApiController
    {
        [HttpGet]
        public IEnumerable<Contact> GetAllContacts()
        {
            var contacts = new Contact[]
            {
                new Contact{Name="zhangsan",PhoneNo = "p123456",EmailAddress = "e123456"},
                new Contact{Name="lisi",PhoneNo = "p223456",EmailAddress = "e323456"},
                new Contact{Name="wangwu",PhoneNo = "p323456",EmailAddress = "e323456"} 
            };
            return contacts;
        }
        [HttpGet]
        public string GetAllString()
        {
            return "123";
        }
    }

    public class Contact
    {
        public string Name { get; set; }

        public string PhoneNo { get; set; }

        public string EmailAddress { get; set; }
    }
}
