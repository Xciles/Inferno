namespace Inferno.BurnApi.Domain.Enums
{
    public enum EFireSeverity
    {
        Unkown = 0,
        LessThan10Meters = 1,
        LargerThan10LessThan100Meters = 2,
        LargerThan100LessThan500Meters = 3,
        LargerThan500LessThan1000Meters = 4,
        LargerThan1000Meters = 5,
        Large = 6
    }
}