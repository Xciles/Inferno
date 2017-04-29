using System;
using Domain.Enums;

namespace Domain
{
	public class FireReport
	{
		public string Description { get; set; }
		public Coordinate Coordinates { get; set; }
		public EFireSeverity FireSeverity { get; set; }
		public DateTime TimeStamp { get; set; }
	}
}