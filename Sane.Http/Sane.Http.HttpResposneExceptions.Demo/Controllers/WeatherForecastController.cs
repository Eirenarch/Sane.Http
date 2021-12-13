namespace Sane.Http.HttpResposneExceptions.Demo.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sane.Http.HttpResponseExceptions;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("/ThrowNotFound")]
    public WeatherForecast ThrowNotFound()
    {
        ThrowHelpers.ThrowNotFound();

        return null;
    }

    [HttpGet("/ThrowNotFoundIfNull")]
    public WeatherForecast ThrowNotFoundIfNull()
    {
        WeatherForecast? weatherForecast = null;

        ThrowHelpers.ThrowNotFoundIfNull(weatherForecast);

        return weatherForecast;
    }

    [HttpGet("/ThrowNotFoundIfNullWithMessage")]
    public WeatherForecast ThrowNotFoundIfNullWithMessage()
    {
        WeatherForecast? weatherForecast = null;

        ThrowHelpers.ThrowNotFoundIfNull(weatherForecast, $"{weatherForecast} not found");

        return weatherForecast;
    }

    [HttpGet("/ThrowNotFoundIfNullWithJson")]
    public WeatherForecast ThrowNotFoundIfNullWithJson()
    {
        WeatherForecast? weatherForecast = null;

        ThrowHelpers.ThrowNotFoundIfNull(weatherForecast, new ProblemDetails { Status = 404, Title = "Not Found", Detail = $"{weatherForecast} not found" });

        return weatherForecast;
    }

    [HttpGet("/ThrowBadRequest")]
    public WeatherForecast ThrowBadRequest()
    {
        ThrowHelpers.ThrowBadRequest();

        return null;
    }

    [HttpGet("/ThrowBadRequestWithMessage")]
    public WeatherForecast ThrowBadRequestWithMessage()
    {
        ThrowHelpers.ThrowBadRequest("Something was invalid");

        return null;
    }

    [HttpGet("/ThrowBadRequestWithJson")]
    public WeatherForecast ThrowBadRequestWithJson()
    {
        ThrowHelpers.ThrowBadRequest(new ProblemDetails { Status = 400, Title = "Bad Request", Detail = $"The request was bad" });

        return null;
    }

    [HttpGet("/ThrowForbidden")]
    public WeatherForecast ThrowForbidden()
    {
        ThrowHelpers.ThrowForbidden();

        return null;
    }

    [HttpGet("/ThrowForbiddenWithMessage")]
    public WeatherForecast ThrowForbiddenWithMessage()
    {
        ThrowHelpers.ThrowForbidden("The thing is forbidden");

        return null;
    }

    [HttpGet("/ThrowForbiddenWithJson")]
    public WeatherForecast ThrowForbiddenWithJson()
    {
        ThrowHelpers.ThrowForbidden(new ProblemDetails { Status = 403, Title = "Forbidden", Detail = $"The thing is forbidden" });

        return null;
    }

    [HttpGet("/ThrowConflict")]
    public WeatherForecast ThrowConflict()
    {
        ThrowHelpers.ThrowConflict();

        return null;
    }

    [HttpGet("/ThrowConflictWithMessage")]
    public WeatherForecast ThrowConflictWithMessage()
    {
        ThrowHelpers.ThrowConflict("There was a conflict");

        return null;
    }

    [HttpGet("/ThrowConflictWithJson")]
    public WeatherForecast ThrowConflictWithJson()
    {
        ThrowHelpers.ThrowConflict(new ProblemDetails { Status = 409, Title = "Conflict", Detail = $"There was a conflict" });

        return null;
    }
}
