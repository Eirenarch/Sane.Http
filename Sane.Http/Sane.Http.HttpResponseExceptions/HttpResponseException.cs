namespace Sane.Http.HttpResponseExceptions;

using System.Net;

public class HttpResponseException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public object? Body { get; }

    /// <summary>
    /// Creates a new HttpResponseException object
    /// </summary>
    /// <param name="statusCode">The HTTP status code to be returned when this exception is thrown</param>
    public HttpResponseException(HttpStatusCode statusCode) : this(statusCode, String.Empty)
    {
    }

    /// <summary>
    /// Creates a new HttpResponseException object
    /// </summary>
    /// <param name="statusCode">The HTTP status code to be returned when this exception is thrown</param>
    /// <param name="message">The message to be delivered as text/plain in the response body</param>
    public HttpResponseException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
    }

    /// <summary>
    /// Creates a new HttpResponseException object
    /// </summary>
    /// <param name="statusCode">The HTTP status code to be returned when this exception is thrown</param>
    /// <param name="body">The object which will be serialized to JSON and delivered as application/json in the response body</param>
    public HttpResponseException(HttpStatusCode statusCode, object body) : base()
    {
        StatusCode = statusCode;
        Body = body;
    }
}