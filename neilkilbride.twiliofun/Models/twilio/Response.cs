using System.Xml;
using System.Xml.Serialization;

namespace neilkilbride.twiliofun.models.twilio
{
    public class Response
    {
        public string Say { get; set; }
        
        public GatherOneDigit Gather { get; set; }
    }

    public class GatherOneDigit
    {
        [XmlAttribute("numDigits")]
        public string NumberOfDigits = "1";

        [XmlAttribute("method")]
        public string Method = "GET";

        [XmlAttribute("action")]
        public string ActionUrl  { get; set; }

        public string Say { get; set; }
    }

    //    using System.Xml.Serialization;

    //namespace neilkilbride.twiliofun.models.twilio
    //    {
    //        public class Response
    //        {
    //            public Response(string message)
    //            {
    //                this.Gather = new GatherOneDigit(message);
    //                this.Test = "Boo";
    //            }

    //            public string Test { get; set; }



    //            /*
    //             * <Gather numDigits="1" action="/api/twilio/statusupdates" method="GET">
    //        <Say>Enter something, or not</Say>
    //    </Gather>
    //             */

    //            [XmlElement(ElementName = "Gather")]
    //            public GatherOneDigit Gather { get; private set; }

    //        }

    //        public class GatherOneDigit
    //        {
    //            public GatherOneDigit(string message)
    //            {
    //                this.Say = message;
    //            }

    //            public string Say { get; private set; }
    //        }
    //    }
}