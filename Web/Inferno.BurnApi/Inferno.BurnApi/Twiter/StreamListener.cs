using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi.Events;
using Tweetinvi.Streaming;

namespace Inferno.BurnApi.Twiter
{
    public static  class StreamListener
    {
        private static IFilteredStream _stream;
        private static readonly string _searchTerm = "nasafires"; //Hardcoded yolo
        static StreamListener()
        {
            _stream = Tweetinvi.Stream.CreateFilteredStream();
            _stream.AddTrack(_searchTerm);

            _stream.MatchingTweetReceived += TweetRecieved;
            _stream.StartStreamMatchingAllConditions();
        }

        public static void Init()
        {
            //Hoi
        }

        public static void TweetRecieved(object sender, MatchedTweetReceivedEventArgs args)
        {
            Console.WriteLine("A tweet containing 'tweetinvi' has been found; the tweet is '" + args.Tweet + "'");
            var coords = args.Tweet.Coordinates;
        }

    }
}
