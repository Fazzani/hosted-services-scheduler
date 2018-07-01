namespace Synker.Scheduled.HostedServices
{
    using System.Threading;
    using System.Threading.Tasks;
    public interface IScheduledTask
    {
        string Schedule { get; }
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}