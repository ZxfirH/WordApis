using Microsoft.AspNetCore.Mvc;

namespace WordApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class WeatherForecastController : ControllerBase
{
    // Default Array of Words.
    private static string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetInput")]
    [Route("~/")]
    public string GetInputs()
    {
        string message = "Please append the URL by adding either of the choices from below  Eg. (localhost:5288/...)\n"
        + "\n\n  * /all - display all 10 words available."
        + "\n\n  * /single - display a single random word."
        + "\n\n  * /sorted - display all 10 words sorted in alphabetical order.";

        return message;
    }

    [HttpGet(Name = "GetSingleWord")]
    [Route("~/single")]
    public string GetSingleWord()
    {
        Random r = new Random();
        var randomElement = r.Next(Summaries.Length);
        return "Single Random Word\n\n  * " + Summaries[randomElement];
    }

    [HttpGet(Name = "GetAllWords")]
    [Route("~/all")]
    public string GetAllWords()
    {
        string alles = string.Join("\n\n  * ", Summaries);
        return "List of All Words\n\n  * " + alles;
    }

    [HttpGet(Name = "GetSortedWords")]
    [Route("~/sorted")]
    public string GetSortedWords()
    {
        
        var sortedSummaries = Summaries.OrderBy(s => s).ToArray();

        string sortedOrder = string.Join("\n\n  * ", sortedSummaries);
        return "List of Sorted Words\n\n  * " + sortedOrder;
    }
}
