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
            return new Response()
                   {
                       Gather = new GatherOneDigit()
                                {
                                    ActionUrl = "/api/twilio/statusupdates",
                                    Say = "This call will provide you with the latest Twilio status updates. How many updates would you like to hear?"
                                }
                   };
        }

        // GET api/twilio/statusupdates
        [System.Web.Http.ActionName("StatusUpdates")]
        public Response GetStatusUpdates(string digits)
        {
            return new Response()
            {
                Say = "You pressed " + digits,
            };
        }

    }
}
