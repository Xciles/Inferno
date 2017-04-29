namespace Inferno.BurnApi.Domain.Enums
{
    public enum EFireSeverity
    {
        Unkown = 0,
        LessThen10Meters = 2,
        LargerThen10LessThen100Meters = 3,
        LargerThen100LessThen500Meters = 4,
        LargerThen500LessThen1000Meters = 4,
        LargerThen1000Meters = 5,
        Large = 6
    }
}