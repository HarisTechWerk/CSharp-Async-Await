using System;
using System.Threading.Tasks;

class Program
{
  static async Task Main(string[] args)
  {
    Console.WriteLine("Start Main");

    var tasks = new[]
    {
      FetchDataAsync("Google", 2000),
      FetchDataAsync("Microsoft", 3000),
      FetchDataAsync("Apple", 1000)
    };

    try
    {
      await Task.WhenAll(tasks);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"🔥 Global Error Handler: {ex.Message}");
    }

    Console.WriteLine("End Main");
  }

  static async Task FetchDataAsync(string site, int delay)
  {
    Console.WriteLine($"Start FetchDataAsync from {site}...");
    await Task.Delay(delay);

    if (site == "Microsoft")
    {
      throw new Exception($"{site} API failed");
    }

    Console.WriteLine($"End FetchDataAsync from {site}");
  }
}

