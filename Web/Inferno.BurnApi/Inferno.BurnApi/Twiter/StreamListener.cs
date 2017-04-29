using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Events;
using Tweetinvi.Models;
using Tweetinvi.Streaming;

namespace Inferno.BurnApi.Twiter
{
    public static  class StreamListener
    {
        private static IFilteredStream _stream;
        private static readonly string _searchTerm = "#nasafires"; //Hardcoded yolo
        static StreamListener()
        {
            Auth.SetUserCredentials("xntbONdOxNF7OPnbadPccUtFn", "dRjqFYRbYtguoZRslgfleldpcpmGsYfT9maBLdH99CqZRNdHoo", "858290769832140801-yPRAOfPfEZnG3rO7KITuzBip2B8aPju", "awRCMwKkMw49UYsrJbajxv0ZfzqbK50pv7cPxcEopsMtt");          
        }

        public static async Task Init()
        {
            _stream = Stream.CreateFilteredStream();
            _stream.AddTrack(_searchTerm);

            _stream.MatchingTweetReceived += TweetRecieved;
            await _stream.StartStreamMatchingAllConditionsAsync();
        }

        public static void TweetRecieved(object sender, MatchedTweetReceivedEventArgs args)
        {
            Console.WriteLine("A tweet containing #nasafires has been found; the tweet is '" + args.Tweet + "'");
        }
    }
}
