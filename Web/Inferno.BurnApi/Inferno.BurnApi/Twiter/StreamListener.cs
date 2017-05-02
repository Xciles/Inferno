using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using Inferno.BurnApi.Business.Interfaces;
using Inferno.BurnApi.Domain;
using Inferno.BurnApi.Domain.Enums;
using Inferno.BurnApi.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Tweetinvi;
using Tweetinvi.Events;
using Tweetinvi.Models;
using Tweetinvi.Streaming;

namespace Inferno.BurnApi.Twiter
{
    public static  class StreamListener
    {
        private static IServiceProvider _serviceProvider;
        private static IFilteredStream _stream;
        private static readonly string _searchTerm = "#nasafires"; //Hardcoded yolo
        static StreamListener()
        {
              //Configure twitter auth here
        }

        public static async Task Init(IServiceProvider service)
        {
            _serviceProvider = service;

            _stream = Stream.CreateFilteredStream();
            _stream.AddTrack(_searchTerm);

            _stream.MatchingTweetReceived += TweetRecieved;
            await _stream.StartStreamMatchingAllConditionsAsync();
        }

        public static void TweetRecieved(object sender, MatchedTweetReceivedEventArgs args)
        {
            if (args.Tweet == null)
            {
                return;
            }

            Console.WriteLine($"Tweet recieved {args.Tweet.FullText}");

            var report = new FireReport()
            {
                TimeStamp = args.Tweet.CreatedAt,
                FireSeverity = EFireSeverity.Unkown, 
                Description = args.Tweet.FullText
            };

            if (report.Description != null && (report.Description.ToLower().Contains("severe") || report.Description.ToLower().Contains("urgent")))
            {
                report.FireSeverity = EFireSeverity.LargerThan100LessThan500Meters;
            }

            if (args.Tweet.Place?.BoundingBox?.Coordinates != null)
            {
                report.BoundingBox = args.Tweet.Place.BoundingBox.Coordinates.Select(x => x.ToGeoCoordinate()).ToList();
                report.Coordinates = new GeoCoordinate(args.Tweet.Place.BoundingBox.Coordinates.Average(x => x.Latitude), args.Tweet.Place.BoundingBox.Coordinates.Average(x => x.Longitude));
            }

            Console.WriteLine($"Trying to store tweet {JsonConvert.SerializeObject(report)}");

            _serviceProvider.GetService<IFireReport>()?.AddReport(report);
        }
    }
}
