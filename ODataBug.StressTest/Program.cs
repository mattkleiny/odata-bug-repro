var isCancelling = false;

Console.CancelKeyPress += (_, _) => { isCancelling = true; };

Parallel.Invoke(
    () =>
    {
        using var client = BuildClient();

        const string url = "/v3/Contact?$expand=BusinessCards";

        var successCount = 0;
        var failedCount = 0;

        while (!isCancelling)
        {
            var response = client.GetAsync(url).Result;

            if (!response.IsSuccessStatusCode)
                Interlocked.Increment(ref failedCount);
            else
                Interlocked.Increment(ref successCount);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
            
            Console.WriteLine($"There were {successCount} successful responses and {failedCount} failed responses for {url}");
        }
    },
    () =>
    {
        using var client = BuildClient();

        const string url = "/v3/Organisation?$expand=Contacts";

        var successCount = 0;
        var failedCount = 0;

        while (!isCancelling)
        {
            var response = client.GetAsync(url).Result;

            if (!response.IsSuccessStatusCode)
                Interlocked.Increment(ref failedCount);
            else
                Interlocked.Increment(ref successCount);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
            
            Console.WriteLine($"There were {successCount} successful responses and {failedCount} failed responses for {url}");
        }
    }
);

static HttpClient BuildClient() => new()
{
    BaseAddress = new Uri("http://odatabug.localtest.me/")
};