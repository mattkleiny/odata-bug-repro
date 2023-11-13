var isCancelling = false;

Console.CancelKeyPress += (_, _) => { isCancelling = true; };

Parallel.Invoke(
    () =>
    {
        using var client = BuildClient();

        const string url = "/v3/Contact?$expand=BusinessCards";

        while (!isCancelling)
        {
            var response = client.GetAsync(url).Result;

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Contact Success! ");
            }
        }
    },
    () =>
    {
        using var client = BuildClient();

        const string url = "/v3/Organisation?$expand=Contacts";

        while (!isCancelling)
        {
            var response = client.GetAsync("/v3/Organization?$expand=Contacts").Result;

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Organization Success! ");
        }
    }
);

static HttpClient BuildClient() => new()
{
   BaseAddress = new Uri("http://odatabug.localtest.me/")
 //BaseAddress = new Uri("http://localhost:5183/")
};