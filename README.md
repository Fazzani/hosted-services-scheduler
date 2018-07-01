# Dotnet core Hosted Services Scheduler

Api for Scheduling dotnet core hosted service 

Example

```csharp
public class QuoteOfTheDayTask : IScheduledTask
    {
        public string Schedule => "* */6 * * *";
        
        public async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var httpClient = new HttpClient();

            var quoteJson = JObject.Parse(await httpClient.GetStringAsync("http://quotes.rest/qod.json"));

            QuoteOfTheDay.Current = JsonConvert.DeserializeObject<QuoteOfTheDay>(quoteJson["contents"]["quotes"][0].ToString());
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
```