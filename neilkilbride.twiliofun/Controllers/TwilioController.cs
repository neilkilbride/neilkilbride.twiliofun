using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web.Http.Results;
using System.Xml.Serialization;

namespace neilkilbride.twiliofun.Controllers
{
    public class TwilioController : ApiController
    {
        
        // GET api/twilio/incoming
        [ActionName("Incoming")]
        public Response GetIncoming()
        {
            return new Response() { Say = "Hello world" };
        }

        [ActionName("Something")]
        public IEnumerable<string> GetSomething()
        {
            return new string[] { "value3", "value4" };
        }
    }


    [DataContract(Namespace = "")]
    public class Response
    {
        [DataMember()]
        public string Say { get; set; }
    }
}
