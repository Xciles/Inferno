using System;
namespace Utils
{
	public static class HeadingHelper
	{
		public static string GetWinddirection(double degrees)
		{
			var index = (int)(degrees + 23) / 45;

			switch (index)
			{
				case 0:
					return "North";
				case 1:
					return "Northeast";
				case 2:
					return "East";
				case 3:
					return "Southeast";
				case 4:
					return "South";
				case 5:
					return "Southwest";
				case 6:
					return "West";
				case 7:
					return "Northwest";
				case 8:
					return "North";
				default:
					return "?";
			}
		}
	}
}
