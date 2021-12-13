namespace Sane.Http.HttpResponseExceptions;

using System.Diagnostics.CodeAnalysis;
using System.Net;

public static class ThrowHelpers
{
    [DoesNotReturn]
    public static void ThrowNotFound()
    {
        ThrowNotFound("");
    }

    [DoesNotReturn]
    public static void ThrowNotFound(string message)
    {
        throw new HttpResponseException(HttpStatusCode.NotFound, message);
    }

    [DoesNotReturn]
    public static void ThrowNotFound(object body)
    {
        throw new HttpResponseException(HttpStatusCode.NotFound, body);
    }

    public static void ThrowNotFoundIfNull([NotNull] object? o)
    {
        if (o == null)
        {
            ThrowNotFound();
        }
    }

    public static void ThrowNotFoundIfNull([NotNull] object? o, string message)
    {
        if (o == null)
        {
            ThrowNotFound(message);
        }
    }

    public static void ThrowNotFoundIfNull([NotNull] object? o, object body)
    {
        if (o == null)
        {
            ThrowNotFound(body);
        }
    }

    [DoesNotReturn]
    public static void ThrowForbidden()
    {
        ThrowForbidden("");
    }

    [DoesNotReturn]
    public static void ThrowForbidden(string message)
    {
        throw new HttpResponseException(HttpStatusCode.Forbidden, message);
    }

    [DoesNotReturn]
    public static void ThrowForbidden(object body)
    {
        throw new HttpResponseException(HttpStatusCode.Forbidden, body);
    }

    [DoesNotReturn]
    public static void ThrowBadRequest()
    {
        ThrowBadRequest("");
    }

    [DoesNotReturn]
    public static void ThrowBadRequest(string message)
    {
        throw new HttpResponseException(HttpStatusCode.BadRequest, message);
    }

    [DoesNotReturn]
    public static void ThrowBadRequest(object body)
    {
        throw new HttpResponseException(HttpStatusCode.BadRequest, body);
    }

    [DoesNotReturn]
    public static void ThrowConflict()
    {
        ThrowConflict("");
    }

    [DoesNotReturn]
    public static void ThrowConflict(string message)
    {
        throw new HttpResponseException(HttpStatusCode.Conflict, message);
    }

    [DoesNotReturn]
    public static void ThrowConflict(object body)
    {
        throw new HttpResponseException(HttpStatusCode.Conflict, body);
    }
}
