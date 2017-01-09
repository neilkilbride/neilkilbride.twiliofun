using System.Collections.Generic;
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
    
}