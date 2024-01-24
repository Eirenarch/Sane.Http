namespace Sane.Http.HttpResponseExceptions;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

internal class HttpResponseExceptionMiddleware
{
    private static JsonSerializerOptions JsonSerializerOptions { get; } = new JsonSerializerOptions(JsonSerializerDefaults.Web);
    private RequestDelegate Next { get; }

    public HttpResponseExceptionMiddleware(RequestDelegate next)
    {
        Next = next;
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Invoke is named by convention for middleware")]
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await Next.Invoke(context);
        }
        catch (HttpResponseException httpResponseException)
        {
            if (context.Response.HasStarted)
            {
                throw;
            }

            context.Response.StatusCode = (int)httpResponseException.StatusCode;
            context.Response.Headers.Clear();

            if (httpResponseException.Body is null)
            {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(httpResponseException.Message);
            }
            else
            {
                if (httpResponseException.Body is ProblemDetails)
                {
                    context.Response.ContentType = "application/problem+json";
                }
                else
                {
                    context.Response.ContentType = "application/json";
                }

                await JsonSerializer.SerializeAsync(context.Response.Body, httpResponseException.Body, JsonSerializerOptions);
            }
        }
    }
}

public static class HttpResponseExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseHttpResponseExceptions(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HttpResponseExceptionMiddleware>();
    }
}
