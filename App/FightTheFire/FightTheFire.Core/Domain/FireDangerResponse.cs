using System;
namespace Domain
{
	public class FireDangerResponse
	{
		public bool IsSafe { get; set; }
		public double? ClosestFireInKm { get; set; }
		public FireReport FireReport { get; set; }
		public double? HeadingDegrees { get; set; }
		public string HeadingString { get; set; }
	}
}