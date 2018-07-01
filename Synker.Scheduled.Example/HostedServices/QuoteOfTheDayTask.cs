namespace Synker.Scheduled.Example.HostedServices
{
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Synker.Scheduled.HostedServices;
    using System;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    // uses https://theysaidso.com/api/
    public class QuoteOfTheDayTask : IScheduledTask
    {
        private readonly ILogger<QuoteOfTheDayTask> _loggger;

        public string Schedule => Environment.GetEnvironmentVariable($"{nameof(QuoteOfTheDayTask)}_ScheduledTask") ?? "* */6 * * *";


        public QuoteOfTheDayTask(ILoggerFactory loggerFactory)
        {
            _loggger = loggerFactory.CreateLogger<QuoteOfTheDayTask>();
        }

        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            using (var httpClient = new HttpClient())
            {
                _loggger.LogDebug($"{nameof(QuoteOfTheDayTask)} Executing start");
                var quoteJson = JObject.Parse(await httpClient.GetStringAsync("http://quotes.rest/qod.json"));
                QuoteOfTheDay.Current = JsonConvert.DeserializeObject<QuoteOfTheDay>(quoteJson["contents"]["quotes"][0].ToString());
                _loggger.LogDebug($"{nameof(QuoteOfTheDayTask)} Executing end");
            }
        }

    }

    public class QuoteOfTheDay
    {
        public static QuoteOfTheDay Current { get; set; }

        static QuoteOfTheDay()
        {
            Current = new QuoteOfTheDay { Quote = "No quote", Author = "Maarten" };
        }

        public string Quote { get; set; }
        public string Author { get; set; }
    }
}