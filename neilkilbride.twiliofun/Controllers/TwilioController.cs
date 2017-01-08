using System.Web.Http;
using Microsoft.Owin.Security.Facebook;
using neilkilbride.twiliofun.models.twilio;

namespace neilkilbride.twiliofun.Controllers
{
    public class TwilioController : ApiController
    {
        
        // GET api/twilio/incoming
        [System.Web.Http.ActionName("Incoming")]
        public Response GetIncomingCallResponse()
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
        public Response GetStatusUpdatesResponse(int digits)
        {
            var generator = new TwilioStatusResponseGenerator();

            return generator.GetStatusesResponse(digits);
        }

    }
}
