using System;
using System.Text;
using QDFeedParser;

namespace neilkilbride.twiliofun.models.twilio
{
    public class TwilioStatusResponseGenerator
    {
        private const string TwilioStatusRssFeed = "https://status.twilio.com/history.rss";
        private readonly IFeed _feed;

        public TwilioStatusResponseGenerator()
        {
            var feedFactory = new HttpFeedFactory();
            _feed = feedFactory.CreateFeed(new Uri(TwilioStatusRssFeed));
        }

        public Response GetStatusesResponse(int numberOfStatuses)
        {
            // Ensure feed has sensible number and doesn't exceed feed max of 25
            if (numberOfStatuses < 1 || numberOfStatuses > 25)
                numberOfStatuses = 25;

            return new Response()
                   {
                       Say = GetStatusString(numberOfStatuses)
                   };
        }

        private string GetStatusString(int numberOfStatuses)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < numberOfStatuses; i++)
            {
                var item = (Rss20FeedItem)_feed.Items[i];
                builder.AppendFormat("Playing {0} status updates.....", numberOfStatuses);
                builder.AppendLine(item.DatePublished.ToUniversalTime().ToString("U") + " UTC. " + item.Title + ".....");
            }

            var sayString = builder.ToString();
            return sayString;
        }
    }
}