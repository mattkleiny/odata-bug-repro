Parallel.Invoke(
    () =>
    {
        using var client = BuildClient();

        while (true)
        {
            var response = client.GetAsync("/v3/Contact?$expand=BusinessCards").Result;

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
        }
    },
    () =>
    {
        using var client = BuildClient();

        while (true)
        {
            var response = client.GetAsync("/v3/Organisation?$expand=Contacts").Result;

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
);

static HttpClient BuildClient() => new()
{
    BaseAddress = new Uri("http://odatabug.localtest.me/")
};