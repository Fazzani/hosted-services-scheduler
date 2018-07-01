namespace Synker.Scheduled.HostedServices.Cron
{
    using System;
    [Serializable]
    public enum CrontabFieldKind
    {
        Minute,
        Hour,
        Day,
        Month,
        DayOfWeek
    }
}