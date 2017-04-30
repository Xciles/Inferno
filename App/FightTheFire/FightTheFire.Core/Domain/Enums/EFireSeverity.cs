using System;
namespace Domain.Enums
{
	public enum EFireSeverity
	{
		Unknown = 0,
		LessThan10Meters = 1,
		LargerThan10LessThan100Meters = 2,
		LargerThan100LessThan500Meters = 3,
		LargerThan500LessThan1000Meters = 4,
		LargerThan1000Meters = 5
	}
}