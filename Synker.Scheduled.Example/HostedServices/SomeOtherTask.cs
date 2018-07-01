using Synker.Scheduled.HostedServices;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Synker.Scheduled.Example.HostedServices
{
    public class SomeOtherTask : IScheduledTask
    {
        public string Schedule => Environment.GetEnvironmentVariable($"{nameof(SomeOtherTask)}_ScheduledTask") ?? "0 5 * * *";

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(5000, cancellationToken);
        }
    }
}