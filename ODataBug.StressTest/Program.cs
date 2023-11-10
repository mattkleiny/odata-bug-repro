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

        while (true)
        {
            var response = client.GetAsync("/v3/Organization?$expand=Contacts").Result;

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Organization Success! ");
            }
        }
    }
);

static HttpClient BuildClient() => new()
{
   // BaseAddress = new Uri("http://odatabug.localtest.me/")
    BaseAddress = new Uri("http://localhost:5183/")
};