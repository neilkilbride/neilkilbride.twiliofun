using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Runtime.Serialization;
using System.Text;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Xml.Serialization;
using neilkilbride.twiliofun.models.twilio;

namespace neilkilbride.twiliofun.Controllers
{
    public class TwilioController : ApiController
    {
        
        // GET api/twilio/incoming
        [System.Web.Http.ActionName("Incoming")]
        public Response GetIncoming()
        {
            return new Response() { Say = "Hello Louise. You are pretty today. Kiss, kiss!" };
        }

        [System.Web.Http.ActionName("PlainIncoming")]
        public HttpResponseMessage GetPlainIncoming()
        {
            return new HttpResponseMessage() { Content = new StringContent("<?xml version=\"1.0\" encoding=\"utf-8\"?><Response><Say>Hello world</Say></Response>", Encoding.UTF8, "application/xml" )};

        }

        [System.Web.Http.ActionName("Something")]
        public IEnumerable<string> GetSomething()
        {
            return new string[] { "value3", "value4" };
        }
    }
}
